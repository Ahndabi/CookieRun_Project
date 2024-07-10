using Firebase.Database;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

// 접근성, 유연성 측면에서 key값을 닉네임으로 하는 것보다 firebase의 userID로 key값을 설정하는 게 더 효율적임
// 닉네임 중복 방지 설정을 위해 DB에 닉네임만을 보관하는 컨테이너를 따로 만들어야 함
[Serializable]
public class dataToSave     // 로그인한 유저가 DB에 저장할 데이터
{
    [SerializeField] string email;       // 이메일
    public string UpdateEmail { get { return email; } set { email = value; } }

    [SerializeField] string nickname;     // 닉네임
    public string UpdateNickName { get { return nickname; } set { nickname = value; } }

    [SerializeField] int totalCoins;  // 유저가 가지고 있는 총 코인 개수
    public int UpdateTotalCoins { get { return totalCoins; } set { totalCoins += value; } }     // 기존에 있는 것에서 value만큼(게임에서 얻은 개수) 더함

    [SerializeField] int totalJellies;    // 유저가 가지고 있는 총 젤리 개수
    public int UpdateTotalJellies { get { return totalJellies; } set { totalJellies += value; } }

    [SerializeField] int bestScore;   // 유저의 최고기록(젤리)
    public int UpdateBestScore { get { return bestScore; } set { bestScore = value; } }
}

public class DataManager : MonoBehaviour
{
	// 플레이어 레벨, 스텟, 최고기록 데이터 저장 등

	// 여기에 젤리, 코인 먹는 UI 데이터 구현할 거임
	public int JellyCount;
	public int CoinCount;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;

	public Players currentPlayer;
	public GameObject player;   // 플레이어 프리팹. 오브젝트

    [SerializeField] dataToSave dts;
    public string userId = null;  // 유저 아이디

    // 데이터베이스에 데이터를 쓰려면 DatabaseReference의 인스턴스가 필요
    DatabaseReference dbRef;

    private void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;     // Get the root reference location of the database
        dts = new dataToSave();
    }

    public void InitItemCount()
	{
		JellyCount = 0;
		CoinCount = 0;
    }

    public void SetUserID(string _userID)
    {
        userId = _userID;
    }

	public void AddJellyCount(int count)
	{
		JellyCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnJellyChanged?.Invoke(JellyCount);
	}

	public void AddCoinCount(int count)
	{
		CoinCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnCointChanged?.Invoke(CoinCount);
	}

	public void DecidePlayer()
	{
		player = Resources.Load<GameObject>($"Prefabs/Players/{currentPlayer.ToString()}");
	}

    public void UpdateData()
    {
        // 최고기록(젤리개수)을 갱신했다면 데이터 수정
        if (CompareHighScore(JellyCount) == true)
           dts.UpdateBestScore = JellyCount;

        SaveData(dts.UpdateEmail, dts.UpdateNickName, CoinCount, JellyCount, dts.UpdateBestScore);
    }

    public void SaveData(string _email, string _nickname, int _coin, int _jelly, int _bestScore)
    {
        dts.UpdateEmail = _email;
        dts.UpdateNickName = _nickname;
        dts.UpdateTotalCoins = _coin;
        dts.UpdateTotalJellies = _jelly;
        dts.UpdateBestScore = _bestScore;

        // 오브젝트(dts)를 문자열로 된 JSON 데이터로 변환
        string json = JsonUtility.ToJson(dts);
        Debug.Log(userId);

        dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json);   // SetRawJsonValueAsync() : 원시 JSON으로 데이터를 쓰거나 대체함
    }

    public void LoadData()
    {
        StartCoroutine(LoadDataRoutine());
    }

    IEnumerator LoadDataRoutine()
    {
        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);    // 요청한 것이 완료될 때까지 기다려야함 

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            print("server data found");
            dts = JsonUtility.FromJson<dataToSave>(jsonData);
        }
        else
        {
            print("no data found");
        }
    }

    public void SaveNickName(string _nickname)  // 닉네임은 따로 DB에 저장해야 함
    {
        dbRef.Child("nicknames").Child(_nickname).SetValueAsync(userId);
    }

    // 최고기록을 갱신했는지 여부
    public bool CompareHighScore(int _currentScore)
    {
        if (dts.UpdateBestScore >= _currentScore) return false;
        else return true;
    }

    // 로그인 후 닉네임 설정할 필요가 있는 유저인지(데이터가 존재하는 유저인지) 확인하는 함수 -> 회원가입만 하고 닉네임 설정 안 했을 경우
    public void CheckToHaveData(string _userID, LobbySceneUI _lobbyUI)
    {
        StartCoroutine(CheckToHaveDataRoutine(_userID, _lobbyUI));
    }

    // 코루틴을 콜백으로 구현해야함 (이 코루틴을 auth나 lobby에서 호출)
    IEnumerator CheckToHaveDataRoutine(string _userID, LobbySceneUI _lobbyUI)
    {
        var serverData = dbRef.Child("users").Child(_userID).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);    // 요청한 것이 완료될 때까지 기다려야함 

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;

        if (snapshot.Exists == false)   // 이전의 데이터가 없었을 경우(닉네임 세팅 해야함) -> 회원가입만 하고 닉네임 설정 안 했을 경우
            _lobbyUI.TurnOnSetNickNameUI();
        if (snapshot.Exists == true)
            _lobbyUI.TurnOnMenuUI();
    }

    // 매개변수로 오는 UserID가 DB에 이미 있는 아이디인지 확인하는 함수
    public void IsNickNameInData(string _NickName, LobbySceneUI _lobbyUI)
    {
        StartCoroutine(CheckNickNameInDataRoutine(_NickName, _lobbyUI));
    }

    IEnumerator CheckNickNameInDataRoutine(string _NickName, LobbySceneUI _lobbyUI)
    {
        var serverData = dbRef.Child("nicknames").Child(_NickName).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);    // 요청한 것이 완료될 때까지 기다려야함 

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;

        // 데이터가 존재하면 닉네임이 있는 거고 데이터가 존재하지 않다면 닉네임이 없다는 뜻
        if (snapshot.Exists == false) { _lobbyUI.SetNickName(); }
        else { _lobbyUI.StartDuplicatedUIRoutine(); }
    }
}

public enum Players
{
	BasicPlayer = 0,
	ZombiePlayer,
}
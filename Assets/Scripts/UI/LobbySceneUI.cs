using Firebase.Auth;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
    [SerializeField] GameObject loginUI;    // 로그인 / 회원가입 창
    [SerializeField] GameObject setNickNameUI;     // 로그인 후 닉네임 입력하는 창
    [SerializeField] GameObject menuUI;     // 로그인 후 게임시작 가능한 창
    [SerializeField] GameObject selectPlayerUI;
    [SerializeField] AuthManager authManager;   // 로그인, 회원가입, 로그아웃에 대한 기능들이 있는 스크립트4

    [SerializeField] TMP_InputField email_Text;  // 입력된 이메일 텍스트
    [SerializeField] TMP_InputField pw_Text;     // 입력된 비밀번호 텍스트
    [SerializeField] TMP_InputField nickName_Text;     // 입력된 닉네임 텍스트

    [SerializeField] GameObject inputPopUpUI;   // 닉네임 입력해달라는 팝업 ui
    [SerializeField] GameObject duplicatedPopUpUI;   // 닉네임 중복됐다는 팝업 ui

    protected override void Awake()
    {
        base.Awake();

        authManager.Init();
        InitLobbyScene();
    }

    public void InitLobbyScene()
    {
        // 현재 로그인한 유저가 없다면
        if (GameManager.Data.userId == null)
        {
            loginUI.SetActive(true);
            menuUI.SetActive(false);
            setNickNameUI.SetActive(false);
            inputPopUpUI.SetActive(false);
            duplicatedPopUpUI.SetActive(false);
        }
        else   // 로그인한 유저가 있다면
        {
            loginUI.SetActive(false);
            menuUI.SetActive(true);
            setNickNameUI.SetActive(false);
            inputPopUpUI.SetActive(false);
            duplicatedPopUpUI.SetActive(false);
        }
    }

    public void SignUpUI()    // 회원가입
    {
        authManager.SignUp(email_Text.text, pw_Text.text);
    }

    public void TurnOnSetNickNameUI()   // 닉네임 설정하는 창 켜기
    {
        loginUI.SetActive(false);
        menuUI.SetActive(false);
        setNickNameUI.SetActive(true);
    }

    public void TurnOnMenuUI()      // 메뉴(게임 시작할 수 있는) 창 켜기
    {
        loginUI.SetActive(false);
        menuUI.SetActive(true);
        setNickNameUI.SetActive(false);
    }

    public void SignInUI()    // 로그인
    {
        authManager.SignIn(email_Text.text, pw_Text.text);
        // 위의 SignIn() 에서는 await로 진행되지만 이 SignInUI에서는 비동기로 처리함. 
        // 그래서 위 함수 호출하고 바로 이 밑의 일들 진행함
    }

    public void LogOutUI()    // 로그아웃
    {
        authManager.LogOut();
    }

    public void OnClickNext()   // 닉네임 입력 후 클릭하는 버튼
    {
        if (nickName_Text == null)
        {
            // 아무것도 입력하지 않았을 경우 팝업UI로 닉네임 입력해달라고 떠야함
            StartCoroutine(InputPopUpUIRoutine());
        }
        else  // 뭐라도 입력이 되었다면 DB에서 해당 닉네임이 있는지 확인
        {
            GameManager.Data.IsNickNameInData(nickName_Text.text, this);
        }
    }

    public void SetNickName()
    {
        setNickNameUI.SetActive(false);
        menuUI.SetActive(true);
        GameManager.Data.SaveNickName(nickName_Text.text);
        GameManager.Data.SaveData(nickName_Text.text, 0, 0, 0);
    }
    
    IEnumerator InputPopUpUIRoutine()
    {
        float time = 0f;
        inputPopUpUI.SetActive(true);
        while (time < 3)
        {
            time += Time.deltaTime;
            yield return null;
        }
        inputPopUpUI.SetActive(false);
    }

    public void StartDuplicatedUIRoutine()
    {
        StartCoroutine(DuplicatedPopUpUIRoutine());
    }

    IEnumerator DuplicatedPopUpUIRoutine()
    {
        float time = 0f;
        duplicatedPopUpUI.SetActive(true);
        while (time < 3)
        {
            time += Time.deltaTime;
            yield return null;
        }
        duplicatedPopUpUI.SetActive(false);
    }

    // 게임 씬으로 넘어가는 함수
    public void LoadGameScene()
	{
        SceneManager.LoadScene(1);
	}

    // 캐릭터 팝업 띄우는 함수
    public void LoadSelectPlayerScene()
    {
        selectPlayerUI.SetActive(true);
    }
}

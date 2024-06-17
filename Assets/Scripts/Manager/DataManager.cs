using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 플레이어 레벨, 스텟 등

	// 여기에 젤리, 코인 먹는 UI 데이터 구현할 거임
	public int JellyCount;
	public int CoinCount;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;

	public Players currentPlayer;
	public GameObject player;	// 플레이어 프리팹. 오브젝트

	public void InitItemCount()
	{
		JellyCount = 0;
		CoinCount = 0;
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
		// Instantiate(player, 게임씬에 있는 프리팹 부모 플레이어);
	}
}

public enum Players
{
	BasicPlayer = 0,
	ZombiePlayer,
}
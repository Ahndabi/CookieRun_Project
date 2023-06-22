using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 플레이어 레벨, 스텟 등

	// 여기에 젤리, 코인 먹는 UI 데이터 구현할 거임
	[SerializeField] int JellyCount;
	[SerializeField] int CoinCount;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 플레이어 레벨, 스텟 등

	// 여기에 젤리, 코인 먹는 UI 데이터 구현할 거임

	// 이건 잠시 갖다 붙인 거!
	[SerializeField] private int shootCount;

	public UnityAction<int> OnShootChanged;

	public void AddShootCount(int count)
	{
		shootCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnShootChanged?.Invoke(shootCount);
	}
}

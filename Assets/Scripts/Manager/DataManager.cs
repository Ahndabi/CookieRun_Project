using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// �÷��̾� ����, ���� ��

	// ���⿡ ����, ���� �Դ� UI ������ ������ ����
	[SerializeField] int JellyCount;
	[SerializeField] int CoinCount;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;

	public void AddJellyCount(int count)
	{
		JellyCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		OnJellyChanged?.Invoke(JellyCount);
	}

	public void AddCoinCount(int count)
	{
		CoinCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		OnCointChanged?.Invoke(CoinCount);
	}
}

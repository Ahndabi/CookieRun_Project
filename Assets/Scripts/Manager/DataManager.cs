using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// �÷��̾� ����, ���� ��

	// ���⿡ ����, ���� �Դ� UI ������ ������ ����

	// �̰� ��� ���� ���� ��!
	[SerializeField] private int shootCount;

	public UnityAction<int> OnShootChanged;

	public void AddShootCount(int count)
	{
		shootCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		OnShootChanged?.Invoke(shootCount);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDie : MonoBehaviour
{
	// HP curHP���� 0�̸� Die
	// ������ �ִϸ��̼�
	// �÷��̾� �۵� ����
	// 2.5 ~ 3�� �ڿ� ���� ����
	[SerializeField] GameObject[] bg;   // ���, �ٴ�
	[SerializeField] GameObject obstacleSpawn;
	public UnityEvent OnDie;

	private void Update()
	{
		if (GameManager.HP.curHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		OnDie?.Invoke();

		for(int i = 0; i < bg.Length; i++)		// ��� ��ũ�Ѹ� ����
		{
			bg[i].GetComponent<BackGround>().enabled = false;
		}

		// ��ֹ� ���� ����
		obstacleSpawn.GetComponent<ObstacleSpawn>().enabled = false;

		// ��ֹ� �̵� ����

		// �÷��̾� ������ٵ� Ű�׸�ƽ���� ����, �ݶ��̴��� ��Ȱ��ȭ
	}
}

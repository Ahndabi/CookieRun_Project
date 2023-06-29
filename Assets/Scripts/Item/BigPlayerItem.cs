using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerItem : Item
{
	[SerializeField] GameObject Player;
	public UnityEvent OnBigger;

	private void Awake()
	{
		// Player = Resources.Load<GameObject>("Prefabs/Player");
	}

	public override void Contact()	// �÷��̾�� ����� ���� �Լ�
	{
		OnBigger?.Invoke();   // Bigger �̺�Ʈ ����
							// 3�� ���� Ŀ���� �ִϸ��̼�. Ŀ���� �ִϸ��̼� �� ���� �����ϰ� scale�� 0.7�� ����. �׸��� ���߿� �ٽ� �۾����� �ִϸ��̼� �ѹ� ����
							// �̰� �� ���ȿ��� ���� (�������̶� ������ �������� ���������� �� ����)
							// �׸��� �۾��� �� �÷��̾� ��������
		Destroy(gameObject);
	}

	// �� �������� ������ �÷��̾ Ŀ�� 
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			Contact();
		}
	}
}

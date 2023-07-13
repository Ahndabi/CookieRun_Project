using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerItem : Item
{
	[SerializeField] GameObject Player;
	Animator anim;

	private void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		anim = Player.GetComponent<Animator>();
	}

	public override void Contact()	// �÷��̾�� ����� ���� �Լ�
	{
		// 3�� ���� Ŀ���� �ִϸ��̼�. Ŀ���� �ִϸ��̼� �� ���� �����ϰ� scale�� 0.7�� ����. �׸��� ���߿� �ٽ� �۾����� �ִϸ��̼� �ѹ� ����
		// �̰� �� ���ȿ��� ���� (�������̶� ������ �������� ���������� �� ����)
		// TODO : �׸��� �۾��� �� �÷��̾� ��������
		anim.SetTrigger("Bigger");
		gameObject.SetActive(false);

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

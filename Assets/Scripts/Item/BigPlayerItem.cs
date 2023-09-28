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
        items.Add(gameObject, 0);  // items ��ųʸ��� �߰�
    }

    public override void Contact()	// �÷��̾�� ����� ���� �Լ�
	{
		// 3�� ���� Ŀ���� �ִϸ��̼�. Ŀ���� �ִϸ��̼� �� ���� �����ϰ� scale�� Ŀ��. �׸��� ���߿� �ٽ� �۾����� �ִϸ��̼� �ѹ� ����
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

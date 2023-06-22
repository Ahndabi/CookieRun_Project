using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// �������� ���� ��!�� ���¸� �������ֱ�
	// 1. ����� ���Ӱ� ��
	// 2. �ִϸ��̼�	0
	// 3. 2�ʰ� �����Ǳ�	0
	// 4. HP ������ ����	0

	// �±� �̸��� Obstacle�� gameObject�� Obstacle�̾��� ������
	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void invincibility()	// 2�� ���� ��������
	{
		Physics2D.IgnoreLayerCollision(3, 8);			// ��ֹ� �ݶ��̴�(���̾�) �����ϱ�
	}

	void CancleLayerCollision()
	{
		CancelInvoke("invincibility");
		Physics2D.IgnoreLayerCollision(3, 8, false);	// �ٽ� ���̾� üũ
	}

	void DecreaseHP()
	{
		GameManager.HP.TakeDamageHP(10);	// 10�� ������ �����鼭 hp�� ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if (col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
			InvokeRepeating("invincibility", 0f, 0f);	// Invincibility �Լ��� �ݺ��ؼ� ��� ȣ��
			Invoke("CancleLayerCollision", 2f);         // 2�� �ڿ� Invicibility�� ��ҽ�Ű�� �Լ� ȣ��
			DecreaseHP();	// HP ����
		}
	}
}

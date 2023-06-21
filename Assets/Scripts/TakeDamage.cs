using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// �������� ���� ��!�� ���¸� �������ֱ�
	// 1. ����� ���Ӱ� ��
	// 2. �ִϸ��̼� 
	// 3. 2�ʰ� �����Ǳ�
	// 4. HP ������ ����

	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void invincibility()	// 2�� ���� ��������
	{
		// ��ֹ� �ݶ��̴� �����ϱ�
		// ���̾ �����ϸ� �����ʳ�? ���̾� üũ����

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if (col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰� �����ؾ��ҵ�
// Obstacle�� ��ֹ��� �����ؼ� Player�� ������ Hp��

public class Obstacle : MonoBehaviour, IDamagable
{
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void damage()
	{
		// ������ ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if(col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
		}
	}
}

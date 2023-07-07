using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
	GameObject target;   // �÷��̾�
	[SerializeField] float speed = 1f;

	private void Start()
	{
		target = GameObject.FindWithTag("Player");		// �÷��̾ �±׸� ���� target���� �־���
	}

	private void FixedUpdate()
	{
		JumpToPlayer();
	}

	void JumpToPlayer()     // �÷��̾ ���� ���� (���⼭�� �ִϸ��̼ǵ� ����)
	{
		gameObject.transform.position = target.transform.position + new Vector3(-3.5f, 1.1f, 0);
		transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);	// �ε巴�� �����̱� ���� Lerp ���
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item�� �⺻����, ������ ����, ������ �ִ�.
// �׷��� ����� ���� ������ ����

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;

	public abstract void Contact();     // �÷��̾�� ����� �� �Լ�
										// 1. Destroy
										// 2. UI���� �ø���
	private void Start()
	{
		ScrollSpeed = 10.5f;
	}

	private void Update()
	{
		Move();
	}

	void Move()
	{
		gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
		Destroy(gameObject, 5f);
	}
}

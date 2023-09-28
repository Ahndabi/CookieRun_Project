using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item�� �⺻����, ������ ����, ������ �ִ�.
// �׷��� ����� ���� ������ ����

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;
	protected AudioClip getSound;
	public bool isMagnetRangeTrigger = false;
	[SerializeField] GameObject pet;
	[SerializeField] Pet petScript;

	public abstract void Contact();     // �÷��̾�� ����� �� �Լ�
										// 1. Destroy
										// 2. UI���� �ø���
	private void Start()
	{
		ScrollSpeed = 10.5f;
		pet = GameObject.FindGameObjectWithTag("Pet");  // �ڼ� �� ���� ��ġ�� �޾ƿ�
		petScript = pet.GetComponent<Pet>();
	}

	private void Update()
	{
		Move();

		if (petScript.isMagnet)     // TODO : &&isMagnetRangeTrigger  Magnet �浹ü �ȿ� trigger�Ǹ�. �浹 trigger �ȿ� bool �ڷ��� ������
		{
			MagnetItemRole();
		}
	}

	void Move()
	{
		gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
		Destroy(gameObject, 5f);
	}

	public void MagnetItemRole()
	{
		// �� �Լ��� ȣ��Ǹ� �������� Pet�� ��ġ�� �̵��ؾ���
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
	}



	// �̰� �� �浹ü ���� �� �ұ�!
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "MagnetRange")
		{
			Debug.Log("�浹ü �ȿ� ����");
			isMagnetRangeTrigger = true;
		}
	}
}

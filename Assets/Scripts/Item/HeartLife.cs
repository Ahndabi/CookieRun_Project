using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	// UI�� HeartLife �ٸ� �����ϱ�
	// 7�ʸ��� y(3.8)�� ������ ��� �����ϱ�
	float time;

	public override void Contact()
	{
		Destroy(gameObject);
	}

	private void OnEnable()
	{
		StartCoroutine(HeartLifeRoutine());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			ChargeHeartUI();
		}
	}

	void ChargeHeartUI()	// UI�� HeartLife �� �����ϴ� �Լ�
	{
		GameManager.HP.curHP += 10f;
	}

	IEnumerator HeartLifeRoutine()
	{
		while(true)
		{
			Instantiate(gameObject, new Vector3(18f, 3.8f, 0f), Quaternion.identity);
			yield return new WaitForSeconds(time);
		}
	}
}

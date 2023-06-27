using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	// UI의 HeartLife 바를 충전하기
	// 7초마다 y(3.8)인 곳에서 계속 등장하기
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

	void ChargeHeartUI()	// UI의 HeartLife 바 충전하는 함수
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

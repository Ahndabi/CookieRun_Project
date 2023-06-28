using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	// UI의 HeartLife 바를
	// 
	public override void Contact()
	{
		Destroy(gameObject);
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
}

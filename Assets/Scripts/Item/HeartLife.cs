using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	// UI�� HeartLife �ٸ�
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

	void ChargeHeartUI()	// UI�� HeartLife �� �����ϴ� �Լ�
	{
		GameManager.HP.curHP += 10f;
	}
}

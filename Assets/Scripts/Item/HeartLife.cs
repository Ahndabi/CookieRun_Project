using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
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
		GameManager.UI.curHP += 20f;
	}
}

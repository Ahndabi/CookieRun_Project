using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Data.AddCoinCount(10);  // 골드코인 먹으면 점수 5씩 증가
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
		}
	}
}

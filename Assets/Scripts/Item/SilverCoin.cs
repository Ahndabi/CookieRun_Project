using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : Item
{
	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Data.AddCoinCount(1);  // 실버코인 먹으면 점수 1씩 증가
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
		}
	}
}

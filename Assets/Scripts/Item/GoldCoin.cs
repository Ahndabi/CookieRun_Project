using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Data.AddCoinCount(10);  // ������� ������ ���� 5�� ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
		}
	}
}

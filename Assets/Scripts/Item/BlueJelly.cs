using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJelly : Item
{
	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Data.AddJellyCount(10);  // ���� ������ ���� 10�� ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Contact();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : Item
{
	public override void Contact()
	{
		Destroy(gameObject);
		GameManager.Data.AddJellyCount(22);  // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
		}
	}
}

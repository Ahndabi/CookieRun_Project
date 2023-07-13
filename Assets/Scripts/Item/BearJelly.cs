using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetItemBearJelly");
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddJellyCount(22);  // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetItemBearJelly", getSound);
		}
	}
}

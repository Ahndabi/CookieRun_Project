using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
        items.Add(gameObject, 10);  // items µñ¼Å³Ê¸®¿¡ Ãß°¡
    }


    public override void Contact()
	{
		gameObject.SetActive(false);

		GameManager.Data.AddJellyCount(items[gameObject]);  // Á©¸® ¸ÔÀ¸¸é Á¡¼ö 10¾¿ Áõ°¡
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetJelly", getSound);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetItemBearJelly");
		items.Add(gameObject, 22);	// items µñ¼Å³Ê¸®¿¡ BearJelly, Á¡¼ö Ãß°¡
	}

	public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddJellyCount(items[gameObject]);  // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
    }

    public override void ContactWithPet()
    {
        gameObject.SetActive(false); 
		GameManager.Data.AddJellyCount(items[gameObject]);  // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("SoundEff_GetItemBearJelly", getSound);
		}
		if (col.gameObject.layer == 10)
		{
			ContactWithPet();
            SoundManager.instance.SFXPlay("SoundEff_GetItemBearJelly", getSound);
        }
    }

}

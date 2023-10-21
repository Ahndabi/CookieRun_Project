using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : Item
{
	[SerializeField] ItemData bearJellyData;

    private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetItemBearJelly");
	}

	public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddJellyCount(bearJellyData.score);	 // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
    }

    public override void ContactWithPet()
    {
        gameObject.SetActive(false); 
        GameManager.Data.AddJellyCount(bearJellyData.score);	 // °õµ¹ÀÌ Á©¸® ¸ÔÀ¸¸é Á¡¼ö 22¾¿ Áõ°¡
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("BearJellySound", bearJellyData.audio);

        }
        if (col.gameObject.layer == 10)
		{
			ContactWithPet();
            SoundManager.instance.SFXPlay("BearJellySound", bearJellyData.audio);
        }
    }

}

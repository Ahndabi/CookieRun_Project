using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
        items.Add(gameObject, 0);  // items µñ¼Å³Ê¸®¿¡ Ãß°¡
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
	}

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			GameManager.Data.IncreaseHp(20);
			SoundManager.instance.SFXPlay("SoundEff_GetJelly", getSound);
		}

        if (col.gameObject.layer == 10)
        {
            ContactWithPet();
            GameManager.Data.IncreaseHp(20);
            SoundManager.instance.SFXPlay("SoundEff_GetJelly", getSound);
        }
    }
}

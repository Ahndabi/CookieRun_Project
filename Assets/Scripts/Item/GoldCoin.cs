using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
    [SerializeField] ItemData goldCointData;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetGoldJelly");
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
        GameManager.Data.AddCoinCount(goldCointData.score);  // 골드코인 먹으면 점수 5씩 증가
	}

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddCoinCount(goldCointData.score);  // 골드코인 먹으면 점수 5씩 증가
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
            SoundManager.instance.SFXPlay("GoldCointSound", goldCointData.audio);
        }

        if (col.gameObject.layer == 10)
        {
            ContactWithPet(); 
            SoundManager.instance.SFXPlay("GoldCointSound", goldCointData.audio);
        }
    }
}

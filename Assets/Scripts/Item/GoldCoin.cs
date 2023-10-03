using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetGoldJelly");
        items.Add(gameObject, 10);  // items 딕셔너리에 추가
    }
    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(items[gameObject]);  // 골드코인 먹으면 점수 5씩 증가
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("SoundEff_GetGoldJelly", getSound);
		}
	}
}

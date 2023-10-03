using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
		items.Add(gameObject, 5);  // items 딕셔너리에 추가
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(items[gameObject]);  // 실버코인 먹으면 점수 1씩 증가
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
		}
	}
}

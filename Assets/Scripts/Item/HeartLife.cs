using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLife : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
        items.Add(gameObject, 0);  // items 딕셔너리에 추가
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			// ChargeHeartUI();
			GameManager.Data.IncreaseHp(20);
			SoundManager.instance.SFXPlay("SoundEff_GetJelly", getSound);
		}
	}

	void ChargeHeartUI()	// UI의 HeartLife 바 충전하는 함수
	{
		GameManager.UI.curHP += 20f;

	}
}

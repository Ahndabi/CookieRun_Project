using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(1);  // 실버코인 먹으면 점수 1씩 증가
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetGoldJelly");
	}
	public override void Contact()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(10);  // ������� ������ ���� 5�� ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetGoldJelly", getSound);
		}
	}
}

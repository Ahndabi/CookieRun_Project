using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
	}


	public override void Contact()
	{
		gameObject.SetActive(false);

		GameManager.Data.AddJellyCount(10);  // ���� ������ ���� 10�� ����
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

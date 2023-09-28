using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetItemBearJelly");
		items.Add(gameObject, 22);	// items ��ųʸ��� BearJelly, ���� �߰�
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddJellyCount(items[gameObject]);  // ������ ���� ������ ���� 22�� ����
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetItemBearJelly", getSound);
		}
	}
}

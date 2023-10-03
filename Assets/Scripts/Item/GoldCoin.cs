using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetGoldJelly");
        items.Add(gameObject, 10);  // items ��ųʸ��� �߰�
    }
    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(items[gameObject]);  // ������� ������ ���� 5�� ����
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

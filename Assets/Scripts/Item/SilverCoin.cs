using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
		items.Add(gameObject, 5);  // items ��ųʸ��� �߰�
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
		GameManager.Data.AddCoinCount(items[gameObject]);  // �ǹ����� ������ ���� 1�� ����
	}

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddJellyCount(items[gameObject]);  // ������ ���� ������ ���� 22�� ����
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Player")
        {
            ContactWithPlayer();
            SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
        }

        if (col.gameObject.layer == 10)
        {
            ContactWithPet();
            SoundManager.instance.SFXPlay("SoundEff_GetGoldJelly", getSound);
        }
    }
}

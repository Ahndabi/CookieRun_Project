using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJelly : Item
{
	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
        items.Add(gameObject, 10);  // items ��ųʸ��� �߰�
    }


    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);

		GameManager.Data.AddJellyCount(items[gameObject]);  // ���� ������ ���� 10�� ����
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
			SoundManager.instance.SFXPlay("SoundEff_GetJelly", getSound);
		}

        if (col.gameObject.layer == 10)
        {
            ContactWithPet();
            SoundManager.instance.SFXPlay("SoundEff_GetItemBearJelly", getSound);
        }
    }
}

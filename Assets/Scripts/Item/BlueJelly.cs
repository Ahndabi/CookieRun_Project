using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJelly : Item
{
    [SerializeField] ItemData blueJulleyData;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetJelly");
    }


    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);

        GameManager.Data.AddJellyCount(blueJulleyData.score);  // ���� ������ ���� 10�� ����
    }

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddJellyCount(blueJulleyData.score);  // ���� ������ ���� 10�� ����
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
            SoundManager.instance.SFXPlay("BlueJellySound", blueJulleyData.audio);
		}

        if (col.gameObject.layer == 10)
        {
            ContactWithPet();
            SoundManager.instance.SFXPlay("BlueJellySound", blueJulleyData.audio);
        }
    }
}

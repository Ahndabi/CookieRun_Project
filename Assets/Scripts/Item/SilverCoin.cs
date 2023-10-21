using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : Item
{
    [SerializeField] ItemData sliverCointData;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
    }

    public override void ContactWithPlayer()
	{
		gameObject.SetActive(false);
        GameManager.Data.AddCoinCount(sliverCointData.score);  // 실버코인 먹으면 점수 1씩 증가
    }

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddCoinCount(sliverCointData.score);  // 실버코인 먹으면 점수 1씩 증가
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Player")
        {
            ContactWithPlayer();
            SoundManager.instance.SFXPlay("SliverCointSound", sliverCointData.audio);
        }

        if (col.gameObject.layer == 10)
        {
            ContactWithPet(); 
            SoundManager.instance.SFXPlay("SliverCointSound", sliverCointData.audio);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
	Pet pet;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
        items.Add(gameObject, 0);  // items 딕셔너리에 추가
    }

    public override void Contact()
	{
		// 펫이 앞으로 나가서(+애니메이션) 앞에 있는 아이템들 자석처럼 끌어당김
		// 펫에 있는 자석함수를 여기서 호출할거임 
		gameObject.SetActive(false);
		pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>();
		pet.Magnet();   // < 이 함수 안에 모든 기능 구현
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

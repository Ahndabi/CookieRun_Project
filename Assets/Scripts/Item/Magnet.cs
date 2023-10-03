using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
	Pet pet;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
        pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>();
        items.Add(gameObject, 0);  // items 딕셔너리에 추가
    }

    public override void ContactWithPlayer()
	{
		// 펫이 앞으로 나가서(+애니메이션) 앞에 있는 아이템들 자석처럼 끌어당김
		// 펫에 있는 자석함수를 여기서 호출할거임 
		gameObject.SetActive(false);
		pet.Magnet();   // < 이 함수 안에 모든 기능 구현
	}

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddJellyCount(items[gameObject]);  // 곰돌이 젤리 먹으면 점수 22씩 증가
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
		}
	}

    public void MagnetItemRole()
    {
        // 이 함수가 호출되면 아이템은 Pet의 위치로 이동해야함
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
    }
}

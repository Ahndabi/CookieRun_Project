using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		// 펫이 앞으로 나가서(+애니메이션) 앞에 있는 아이템들 자석처럼 끌어당김
		// LayerMask나 콜라이더 등으로 앞에 일정 범위를 체크하고 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerItem : Item
{
	[SerializeField] GameObject Player;
	Animator anim;

	private void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		anim = Player.GetComponent<Animator>();
        items.Add(gameObject, 0);  // items 딕셔너리에 추가
    }

    public override void Contact()	// 플레이어랑 닿았을 때의 함수
	{
		// 3초 동안 커지는 애니메이션. 커지는 애니메이션 한 번만 실행하고 scale이 커짐. 그리고 나중에 다시 작아지는 애니메이션 한번 실행
		// 이거 할 동안에는 무적 (아이템이랑 닿으면 아이템이 오른쪽으로 다 날라감)
		// TODO : 그리고 작아질 때 플레이어 깜빡깜빡
		anim.SetTrigger("Bigger");
		gameObject.SetActive(false);

	}

	// 이 아이템을 먹으면 플레이어가 커짐 
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			Contact();
		}
	}
}

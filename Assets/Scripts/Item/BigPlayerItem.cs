using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerItem : Item
{
	[SerializeField] GameObject Player;
	public UnityEvent OnBigger;

	private void Awake()
	{
		// Player = Resources.Load<GameObject>("Prefabs/Player");
	}

	public override void Contact()	// 플레이어랑 닿았을 때의 함수
	{
		OnBigger?.Invoke();   // Bigger 이벤트 실행
							// 3초 동안 커지는 애니메이션. 커지는 애니메이션 한 번만 실행하고 scale를 0.7로 고정. 그리고 나중에 다시 작아지는 애니메이션 한번 실행
							// 이거 할 동안에는 무적 (아이템이랑 닿으면 아이템이 오른쪽으로 다 날라감)
							// 그리고 작아질 때 플레이어 깜빡깜빡
		Destroy(gameObject);
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

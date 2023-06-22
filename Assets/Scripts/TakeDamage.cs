using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// 데미지를 받을 때!의 상태를 구현해주기
	// 1. 배경이 벌겋게 됨
	// 2. 애니메이션	0
	// 3. 2초간 무적되기	0
	// 4. HP 데미지 깎임	0

	// 태그 이름이 Obstacle인 gameObject가 Obstacle이었음 좋겠음
	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void invincibility()	// 2초 동안 무적상태
	{
		Physics2D.IgnoreLayerCollision(3, 8);			// 장애물 콜라이더(레이어) 무시하기
	}

	void CancleLayerCollision()
	{
		CancelInvoke("invincibility");
		Physics2D.IgnoreLayerCollision(3, 8, false);	// 다시 레이어 체크
	}

	void DecreaseHP()
	{
		GameManager.HP.TakeDamageHP(10);	// 10씩 데미지 받으면서 hp가 감소
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 장애물을 통과하면 다치는 애니메이션 실행
		if (col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
			InvokeRepeating("invincibility", 0f, 0f);	// Invincibility 함수를 반복해서 계속 호출
			Invoke("CancleLayerCollision", 2f);         // 2초 뒤에 Invicibility를 취소시키는 함수 호출
			DecreaseHP();	// HP 감소
		}
	}
}

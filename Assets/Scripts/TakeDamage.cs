using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// 데미지를 받을 때!의 상태를 구현해주기
	// 1. 배경이 벌겋게 됨
	// 2. 애니메이션 
	// 3. 2초간 무적되기
	// 4. HP 데미지 깎임

	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void invincibility()	// 2초 동안 무적상태
	{
		// 장애물 콜라이더 무시하기
		// 레이어를 무시하면 되지않나? 레이어 체크해제

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 장애물을 통과하면 다치는 애니메이션 실행
		if (col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
		}
	}
}

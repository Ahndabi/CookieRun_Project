using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이거 수정해야할듯
// Obstacle은 장애물에 부착해서 Player랑 닿으면 Hp바

public class Obstacle : MonoBehaviour, IDamagable
{
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void damage()
	{
		// 데미지 깎임
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 장애물을 통과하면 다치는 애니메이션 실행
		if(col.gameObject.tag == "Obstacle")
		{
			anim.SetTrigger("TakeDamage");
		}
	}
}

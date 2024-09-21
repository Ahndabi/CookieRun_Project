using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
	// 플레이어 하위 자식에 점프하기 위한 발판(콜라이더)이 따로 있기 때문에 스크립트도 따로 만들어줌

	Animator anim;
	PlayerController playerController;

	private void Awake()
	{
		anim = GetComponentInParent<Animator>();
		playerController = GetComponentInParent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Ground" && playerController.isJump == true)
		{
			playerController.isJump = false;
			anim.SetTrigger("Land");
		}
	}
}

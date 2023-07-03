using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
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

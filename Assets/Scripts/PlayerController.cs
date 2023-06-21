using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float jumpSpeed;
	bool isGrounded = true;
	bool oneJump = false;		// 1단 점프를 한 번 했는지

	Rigidbody2D rb;
	Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Slide();
		Debug.DrawRay(transform.position, Vector3.down * 2f, Color.green);
	}

	void Jump()
	{
		// 2단 점프만 가능하도록 
		if (GroundCheck())       // 1. 바닥이면 점프가능
		{
			oneJump = true;      // 1단점프 true
			anim.SetTrigger("Jump1");
			rb.velocity = Vector2.up * jumpSpeed;
		}
		else if (!GroundCheck() && oneJump)		// 1. 공중이면서	2. 1단점프를 한 경우
		{
			oneJump = false;     // 1단 점프는 이미 했음
			rb.velocity = Vector2.up * jumpSpeed;       // 한 번 더 점프 가능
			anim.SetTrigger("Jump2");
		}
		else 
		{
			return;
		}
	}

	void OnJump(InputValue value)
	{
		Jump();
	}

	private bool GroundCheck()
	{
		// 바닥인지 체크하고 2단 점프만 가능하도록 해야함

		// 이거 계속 안 됐던 이유가 2.1f가 아니라 1.5였음.. Debug.DrawRay로 그려주니까 엄청 짧아있었음
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		// Debug.DrawRay(transform.position, Vector3.down * 2f, Color.green);	// 레이어 그려주기

		if (hit.collider != null)	// 레이어 부딪힌 게 있는 경우
		{
			isGrounded = true;
			oneJump = false;		// 바닥이니까 1단점프를 false로
		}
		else 
			isGrounded = false;
		
		return isGrounded;
	}

	void Slide()
	{
		// GetKeyDown : 키를 누르고 있는 동안 anim.Slide 하도록
		if (Input.GetKeyDown(KeyCode.S))
		{
			anim.SetBool("Slide", true);
		}
		if (Input.GetKeyUp(KeyCode.S)) 
		{
			anim.SetBool("Slide", false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float jumpSpeed;
	bool isGrounded = true;
	bool oneJump = false;       // 1단 점프를 한 번 했는지
	bool isSlide = false;
	public bool isJump = false;

	Rigidbody2D rb;
	public Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		Debug.DrawRay(transform.position, Vector3.down * 2f, Color.green);
	}

	public void Jump()
	{
		// 2단 점프만 가능하도록 
		if (GroundCheck())       // 1. 바닥이면 점프가능
		{
			isJump = true;
			oneJump = true;      // 1단점프 true
			anim.SetTrigger("Jump1");
			rb.velocity = Vector2.up * jumpSpeed;
		}
		else if (!GroundCheck() && oneJump)     // 1. 공중이면서	2. 1단점프를 한 경우
		{
			isJump = true;
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

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));

		if (hit.collider != null)	// 레이어 부딪힌 게 있는 경우
		{
			isGrounded = true;
			oneJump = false;		// 바닥이니까 1단점프를 false로
		}
		else 
			isGrounded = false;

		// 1단 점프 시작할 땐 isGround가 true로 뜨고, 2단 점프 시작할 땐 false로 뜸! 잘 맞게 뜨는 거임 2단점프만을 위한 groundcheck라서
		// Debug.Log(isGrounded);
		return isGrounded;
	}

	void OnSlide(InputValue value)
	{
		Slide();
	}

	public void Slide()
	{
		anim.SetTrigger("Slide");
	}

	public void Move()
	{
		anim.SetTrigger("Move");
	}
}

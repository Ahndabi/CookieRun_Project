using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerBase
{
	// 점프, 슬라이드, 애니메이션 

	[SerializeField] float jumpSpeed = 20;
	bool isGrounded = true;
	bool oneJump = false;       // 1단 점프를 한 번 했는지
	public bool isJump = false;

	public AudioClip jumpSound;
	public AudioClip slideSound;

	protected override void Awake()
	{
		base.Awake();

		jumpSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_jump");
		slideSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_slide");
	}

    private void Start()
    {
		gameObject.SetActive(true);
    }

    protected virtual void Jump()
	{
		// 2단 점프만 가능하도록 
		if (GroundCheck())       // 1. 바닥이면 점프가능
		{
			anim.SetTrigger("Jump1");
			isJump = true;
			oneJump = true;      // 1단점프 true
			rb.velocity = Vector2.up * jumpSpeed;
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}
		else if (!GroundCheck() && oneJump)     // 1. 공중이면서	2. 1단점프를 한 경우
		{
			anim.SetTrigger("Jump2");
			isJump = true;
			oneJump = false;     // 1단 점프는 이미 했음
			rb.velocity = Vector2.up * jumpSpeed;       // 한 번 더 점프 가능
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
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

	protected virtual bool GroundCheck()
	{
		// 바닥인지 체크하고 2단 점프만 가능하도록 해야함

		RaycastHit2D hit;

		if (anim.GetCurrentAnimatorStateInfo(1).IsName("Bigger"))
		{
            hit = Physics2D.Raycast(transform.position, Vector2.down, 2.8f, LayerMask.GetMask("Ground"));
        }
        else
		{
			hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		}

		if (hit.collider != null)	// 레이어 부딪힌 게 있는 경우
		{
			isGrounded = true;
			isJump = false;
			oneJump = false;		// 바닥이니까 1단점프를 false로
		}
		else 
			isGrounded = false;

		return isGrounded;
	}

	void OnSlide(InputValue value)
	{
		Slide();

		SoundManager.instance.SFXPlay("cookie0001_slide", slideSound);
	}

	protected virtual void Slide()
	{
		anim.SetTrigger("Slide");
	}

    protected virtual void Move()
	{
		anim.SetTrigger("Move");
	}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerBase
{
	// ����, �����̵�, �ִϸ��̼� 

	[SerializeField] float jumpSpeed = 20;
	bool isGrounded = true;
	bool oneJump = false;       // 1�� ������ �� �� �ߴ���
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
		// 2�� ������ �����ϵ��� 
		if (GroundCheck())       // 1. �ٴ��̸� ��������
		{
			anim.SetTrigger("Jump1");
			isJump = true;
			oneJump = true;      // 1������ true
			rb.velocity = Vector2.up * jumpSpeed;
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}
		else if (!GroundCheck() && oneJump)     // 1. �����̸鼭	2. 1�������� �� ���
		{
			anim.SetTrigger("Jump2");
			isJump = true;
			oneJump = false;     // 1�� ������ �̹� ����
			rb.velocity = Vector2.up * jumpSpeed;       // �� �� �� ���� ����
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
		// �ٴ����� üũ�ϰ� 2�� ������ �����ϵ��� �ؾ���

		RaycastHit2D hit;

		if (anim.GetCurrentAnimatorStateInfo(1).IsName("Bigger"))
		{
            hit = Physics2D.Raycast(transform.position, Vector2.down, 2.8f, LayerMask.GetMask("Ground"));
        }
        else
		{
			hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		}

		if (hit.collider != null)	// ���̾� �ε��� �� �ִ� ���
		{
			isGrounded = true;
			isJump = false;
			oneJump = false;		// �ٴ��̴ϱ� 1�������� false��
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

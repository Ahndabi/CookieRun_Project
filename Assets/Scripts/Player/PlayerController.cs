using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float jumpSpeed;
	bool isGrounded = true;
	bool oneJump = false;       // 1�� ������ �� �� �ߴ���
	bool isSlide = false;
	public bool isJump = false;

	GameObject Player;

	Rigidbody2D rb;
	public Animator anim;

	private void Awake()
	{
		Player = GameManager.Resource.Load<GameObject>("Prefabs/Player");
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	public void Jump()
	{
		// 2�� ������ �����ϵ��� 
		if (GroundCheck())       // 1. �ٴ��̸� ��������
		{
			isJump = true;
			oneJump = true;      // 1������ true
			anim.SetTrigger("Jump1");
			rb.velocity = Vector2.up * jumpSpeed;
		}
		else if (!GroundCheck() && oneJump)     // 1. �����̸鼭	2. 1�������� �� ���
		{
			isJump = true;
			oneJump = false;     // 1�� ������ �̹� ����
			rb.velocity = Vector2.up * jumpSpeed;       // �� �� �� ���� ����
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
		// �ٴ����� üũ�ϰ� 2�� ������ �����ϵ��� �ؾ���

		RaycastHit2D hit;

		// Bigger ���¸� ����ĳ��Ʈ�� 2.5f�� ���ְ� �⺻ ���¸� 2f�� ����
		if (anim.GetCurrentAnimatorStateInfo(1).nameHash == Animator.StringToHash("Item Layer.Bigger"))
		{
			Debug.Log("Bigger���� ");
			hit = Physics2D.Raycast(transform.position, Vector2.down, 2.5f, LayerMask.GetMask("Ground"));

		}
		else
		{
			hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		}


		if (hit.collider != null)	// ���̾� �ε��� �� �ִ� ���
		{
			isGrounded = true;
			oneJump = false;		// �ٴ��̴ϱ� 1�������� false��
		}
		else 
			isGrounded = false;

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

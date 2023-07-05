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

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));

		if (hit.collider != null)	// ���̾� �ε��� �� �ִ� ���
		{
			isGrounded = true;
			oneJump = false;		// �ٴ��̴ϱ� 1�������� false��
		}
		else 
			isGrounded = false;

		// 1�� ���� ������ �� isGround�� true�� �߰�, 2�� ���� ������ �� false�� ��! �� �°� �ߴ� ���� 2���������� ���� groundcheck��
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float jumpSpeed;
	bool isGrounded = true;
	bool oneJump = false;		// 1�� ������ �� �� �ߴ���

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
		// 2�� ������ �����ϵ��� 
		if (GroundCheck())       // 1. �ٴ��̸� ��������
		{
			oneJump = true;      // 1������ true
			anim.SetTrigger("Jump1");
			rb.velocity = Vector2.up * jumpSpeed;
		}
		else if (!GroundCheck() && oneJump)		// 1. �����̸鼭	2. 1�������� �� ���
		{
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

		// �̰� ��� �� �ƴ� ������ 2.1f�� �ƴ϶� 1.5����.. Debug.DrawRay�� �׷��ִϱ� ��û ª���־���
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		// Debug.DrawRay(transform.position, Vector3.down * 2f, Color.green);	// ���̾� �׷��ֱ�

		if (hit.collider != null)	// ���̾� �ε��� �� �ִ� ���
		{
			isGrounded = true;
			oneJump = false;		// �ٴ��̴ϱ� 1�������� false��
		}
		else 
			isGrounded = false;
		
		return isGrounded;
	}

	void Slide()
	{
		// GetKeyDown : Ű�� ������ �ִ� ���� anim.Slide �ϵ���
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

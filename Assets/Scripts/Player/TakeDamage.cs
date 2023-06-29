using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// �������� ���� ��!�� ���¸� �������ֱ�
	// 1. ����� ���Ӱ� ��
	// 2. �ִϸ��̼�		0
	// 3. 2�ʰ� �����Ǳ�	0 + �÷��̾� ����ȭ, ��������
	// 4. HP ������ ����	0
	// 5. ī�޶� ��鸲 1��	0
	// HP�� 30% ���� ������ ��� ���Ӱ� ���������Ÿ�


	// ����ȭ�� �ִϸ��̼�����?

	Vector3 cameraPos;
	Animator anim;
	SpriteRenderer sp;
	Material mat;
	public UnityEvent OnTakeDamage;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		sp = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // ī�޶� ��ġ�� ������ ���� ī�޶� ��ġ
		mat = sp.material;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if (col.gameObject.tag == "Obstacle")
		{
			OnTakeDamage?.Invoke();
			//anim.SetTrigger("TakeDamage");
			InvokeRepeating("IgnoreLayer", 0f, 0f);   // Invincibility �Լ��� �ݺ��ؼ� ��� ȣ��
			Invoke("CancleLayerCollision", 2f);         // 2�� �ڿ� Invicibility�� ��ҽ�Ű�� �Լ� ȣ��
			DecreaseHP();   // HP ����
			CameraShake();
			Invoke("StopCameraShake", 0.1f);
		}
	}

	void IgnoreLayer()	// 2�� ���� ��ֹ� ���
	{
		Physics2D.IgnoreLayerCollision(3, 8);           // ��ֹ� �ݶ��̴�(���̾�) �����ϱ�
	}

	/*
	void PlayerTransparency()		// �÷��̾� ����ȭ
	{
		Color matColor = mat.color;
		matColor.a = 0.5f;
		mat.color = matColor;
		// ���⼭ invoke�� 0.1�� �ڿ� �÷��̾� ���� ������ ���ƿ��� �Լ� ȣ���ϱ�
	}*/


	void CancleLayerCollision()
	{
		CancelInvoke("invincibility");
		Physics2D.IgnoreLayerCollision(3, 8, false);	// �ٽ� ���̾� üũ
	}

	void DecreaseHP()
	{
		GameManager.HP.TakeDamageHP(10);	// 10�� ������ �����鼭 hp�� ����
	}

	void CameraShake()		// ī�޶� ��鸮��
	{
		float x = Random.Range(0f, 0.7f);
		float y = Random.Range(0f, 0.7f);

		Camera.main.transform.position += new Vector3(x, y, 0);
	}

	void StopCameraShake()	// ī�޶� ��ġ �����·� ����
	{
		Camera.main.transform.position = cameraPos;
	}
}

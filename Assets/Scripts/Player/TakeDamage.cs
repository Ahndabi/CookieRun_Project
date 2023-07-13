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

	Vector3 cameraPos;
	Animator anim;
	SpriteRenderer sp;
	Material mat;
	Color oriMat;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		sp = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // ī�޶� ��ġ�� ������ ���� ī�޶� ��ġ
		mat = sp.material;
		oriMat.a = gameObject.GetComponent<SpriteRenderer>().material.color.a;    // ���� �⺻ �÷��̾��� Matrial

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if (col.gameObject.tag == "Obstacle")
		{
			DecreaseHP();   // HP ����

			anim.SetTrigger("TakeDamage");

			StartCoroutine(CameraShakeRoutine());			// ī�޶� ���� �Լ� ȣ��
			StartCoroutine(IgnoreLayerRoutine());			// 2�� ���� IgnoreLayer �Լ��� �ݺ��ؼ� ��� ȣ��
															//StartCoroutine(PlayerTransparencyRoutine());	// �÷��̾� ����ȭ
															//InvokeRepeating("PlayerTransparency", 0f, 0.2f);
			//mat.color = oriMat;
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator IgnoreLayerRoutine()		// *** ���⼭ ���̾� ������ �� 1.5�� �� ������ BigItem������ ���̾� ���õ� ä�� �� ��ũ��Ʈ �����ż� Destroy�ȵ� �̤�
	{
		Physics2D.IgnoreLayerCollision(3, 8, true);           // ��ֹ� �ݶ��̴�(���̾�) �����ϱ�
		yield return new WaitForSeconds(1.5f);
		Physics2D.IgnoreLayerCollision(3, 8, false);    // �ٽ� ���̾� üũ
	}

	IEnumerator CameraShakeRoutine()
	{
		float x = Random.Range(0f, 0.8f);
		float y = Random.Range(0f, 0.8f);
		Camera.main.transform.position += new Vector3(x, y, 0);
		yield return new WaitForSeconds(0.1f);
		Camera.main.transform.position = cameraPos;		// ī�޶� ��ġ ���󺹱�
	}



	// �÷��̾� ����ȭ �ϴ� �� �ڷ�ƾ���� 0.1�ʸ��� �ݺ��ϰ� �ϸ� �����ʳ�?
	IEnumerator PlayerTransparencyRoutine()
	{
		WaitForSeconds waitsec = new WaitForSeconds(0.2f);

		//oriMat = mat;	// oriMat�� �⺻

		for (int i = 0; i < 2; i++)
		{
			PlayerTransparency();
			yield return waitsec;
		}

		for (int j = 0; j < 2; j++)
		{
			mat.color = oriMat;
			yield return waitsec;
		}

		//PlayerTransparency();
		//yield return new WaitForSeconds(2f);
	}

	void OriState()
	{
		mat.color = oriMat;
	}

	void PlayerTransparency()		// �÷��̾� ����ȭ
	{
		Color matColor = mat.color;
		matColor.a = 0.5f;
		mat.color = matColor;
		// ���⼭ invoke�� 0.1�� �ڿ� �÷��̾� ���� ������ ���ƿ��� �Լ� ȣ���ϱ�
		//Invoke("OriState", 0.2f);
	}

	void DecreaseHP()
	{
		GameManager.UI.TakeDamageHP(10);	// 10�� ������ �����鼭 hp�� ����
	}
}

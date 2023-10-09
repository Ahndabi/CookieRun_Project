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

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // ī�޶� ��ġ�� ������ ���� ī�޶� ��ġ
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// ��ֹ��� ����ϸ� ��ġ�� �ִϸ��̼� ����
		if (col.gameObject.tag == "Obstacle")
		{
			GameManager.Data.DecreaseHp(10);

			anim.SetTrigger("TakeDamage");

			StartCoroutine(CameraShakeRoutine());			// ī�޶� ���� �Լ� ȣ��
			StartCoroutine(IgnoreLayerRoutine());			// 2�� ���� IgnoreLayer �Լ��� �ݺ��ؼ� ��� ȣ��
															// StartCoroutine(PlayerTransparencyRoutine());	// �÷��̾� ����ȭ
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
}

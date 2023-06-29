using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerController : MonoBehaviour
{
	// Ŀ���� �������� �԰� �÷��̾ Ŀ���� �� �÷��̾��� ��� ����
	// 1. �������� ���� �ʴ´� (HP�� �� ����)
	// 2. �������� ���������� ƨ�ܳ�

	GameObject Obstacle;
	TakeDamage takeDamage;
	public UnityEvent OnOriginal;   // ���� ���·� ���ư��� �̺�Ʈ
	bool isBig = false;

	private void Awake()
	{
		takeDamage = GetComponent<TakeDamage>();
		Obstacle = GameObject.FindGameObjectWithTag("Obstacle");
	}

	public void NoneDamage()
	{
		// takedamage ��ũ��Ʈ�� ��Ȱ��ȭ ��Ű�� �����ʳ�? - �ٵ� ��Ȱ��ȭ�ϴϱ� �̻��ϰ� �ż� ������ �غ�����
		isBig = true;
		Destroy(takeDamage);
		Invoke("OriginalSize", 3f); // 3�� �ڿ� �����·�
		//InvokeRepeating("HitObstacle", 0f, 0f);
		//Invoke("HitObstacle", 3f);		// 3�� �ڿ� �����·�
		Invoke("AddTakeDamage", 4f);	// 4�� �ڿ� �����·�
	}

	public void OriginalSize()	// �ٽ� �����·� ������	- Invoke �Լ��� ������ ���� �� 3�� �ڿ� ȣ��
	{
		OnOriginal?.Invoke();	// ũ�Ⱑ �پ��� �ִϸ��̼� �߰�

		// �������� ȿ���� �ؾ���
	}

	public void AddTakeDamage()
	{
		gameObject.AddComponent<TakeDamage>();      // �ٽ� TakeDamage ��ũ��Ʈ �߰�
	}

	public void HitObstacle()	// ��ֹ� �ε����� ƨ�ܳ���
	{
		// ī�޶����ũó�� ������ �̿��ؼ� ������ ������ ������ Ȯ �̵��ϵ���
		// ������ �ӿ��� y�� ������~ �������� ������ �������� �س��� transform.position += �� ��ġ��ŭ �̵���Ű�� 1�� �ڿ� destroy
		// x�� 13. y�� -9 ~ 9����
		int y = Random.Range(-9, 9);
		// tag�� Obstacle�� ������Ʈ�� ������ �� ������Ʈ�� ����

		Obstacle.transform.position = Vector2.MoveTowards(Obstacle.transform.position, new Vector2(13, y), 0.1f);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// �÷��̾ ��ֹ��̶� Ʈ�����ϸ� HitObstacle ȣ��
		if(col.tag == "Obstacle" && isBig)
		{
			HitObstacle();
			Debug.Log("�ñ�");
		}
	}

	public void CancleHitObstacle()
	{
		CancelInvoke("HitObstacle");
		isBig = false;
	}
}

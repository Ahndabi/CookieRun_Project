using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class BigPlayerController : MonoBehaviour
{
	// Ŀ���� �������� �԰� �÷��̾ Ŀ���� �� �÷��̾��� ��� ����
	// 1. �������� ���� �ʴ´� (HP�� �� ����)
	// 2. �������� ���������� ƨ�ܳ�

	public GameObject test;
	public GameObject[] Obstacle;
	TakeDamage takeDamage;
	public UnityEvent OnOriginal;   // ���� ���·� ���ư��� �̺�Ʈ
	bool isBig = false;

	private void Awake()
	{
		takeDamage = GetComponent<TakeDamage>();
		Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
	}

	private void Update()
	{
		// ���⿡ ��ֹ� �±� ã���� �Ǵ� �� �ƴѰ�
	}

	public void NoneDamage()	// �÷��̾ Ŀ���� �ִϸ��̼ǿ� �̺�Ʈ�� ���� �Լ�
	{
		isBig = true;
		Destroy(takeDamage);    // takedamage ��ũ��Ʈ�� ��Ȱ��ȭ ��Ű�� �����ʳ�? - �ٵ� ��Ȱ��ȭ�ϴϱ� �̻��ϰ� �ż� ������ �غ�����
		Invoke("OriginalSize", 3f);		// 3�� �ڿ� ũ�� �����·�
		InvokeRepeating("DestroyObstacle", 0f, 0f);
		Invoke("AddTakeDamage", 4f);	// 4�� �ڿ� ������ �޴� �� �����·�
	}

	public void OriginalSize()	// �ٽ� �����·� ������	- Invoke �Լ��� ������ ���� �� 3�� �ڿ� ȣ��
	{
		OnOriginal?.Invoke();	// ũ�Ⱑ �پ��� �ִϸ��̼� �߰�

		// TODO : �������� ȿ���� �ؾ���
	}

	public void AddTakeDamage()
	{
		gameObject.AddComponent<TakeDamage>();      // �ٽ� TakeDamage ��ũ��Ʈ �߰�
	}

	public void DestroyObstacle()	// ��ֹ� �ε����� ��ֹ� �����ϱ�
	{

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			DestroyObstacle();
			Debug.Log("��ֹ� �ε���");
		}
	}

	public void CancleHitObstacle()
	{
		CancelInvoke("DestroyObstacle");
		isBig = false;
	}
}

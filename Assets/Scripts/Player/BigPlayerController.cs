using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class BigPlayerController : MonoBehaviour
{
	TakeDamage takeDamage;
	Animator anim;
	bool isBig = false;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void NoneDamage()	// �÷��̾ Ŀ���� �ִϸ��̼ǿ� �̺�Ʈ�� ���� �Լ�
	{
        takeDamage = GetComponent<TakeDamage>();
        isBig = true;
		Destroy(takeDamage);
		StartCoroutine(OriginalSizeRoutine());
		StartCoroutine(AddTakeDamageRoutine());
		
	}

	IEnumerator OriginalSizeRoutine()
	{
		yield return new WaitForSeconds(3f);
		anim.SetTrigger("Smaller");     // ���� ���·� ���ư� (�۾���)
		isBig = false;

		// TODO : �������� ȿ���� �߰��ؾ���
	}

	IEnumerator AddTakeDamageRoutine()
	{
		yield return new WaitForSeconds(4f);

		gameObject.AddComponent<TakeDamage>();      // �ٽ� TakeDamage ��ũ��Ʈ �߰�
	}


	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			Destroy(col.gameObject);		// �ε��� ��ֹ��� Destroy
		}
	}
}

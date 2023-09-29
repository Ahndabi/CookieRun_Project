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

	public void NoneDamage()	// 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수
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
		anim.SetTrigger("Smaller");     // 원래 상태로 돌아감 (작아짐)
		isBig = false;

		// TODO : 깜빡깜빡 효과도 추가해야함
	}

	IEnumerator AddTakeDamageRoutine()
	{
		yield return new WaitForSeconds(4f);

		gameObject.AddComponent<TakeDamage>();      // 다시 TakeDamage 스크립트 추가
	}


	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			Destroy(col.gameObject);		// 부딪힌 장애물은 Destroy
		}
	}
}

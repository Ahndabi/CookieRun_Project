using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class BigPlayerController : MonoBehaviour
{
	// 커지는 아이템을 먹고 플레이어가 커졌을 때 플레이어의 기능 구현
	// 1. 데미지를 받지 않는다 (HP도 안 닳음)
	// 2. 아이템을 오른쪽으로 튕겨냄

	public GameObject test;
	public GameObject[] Obstacle;
	TakeDamage takeDamage;
	public UnityEvent OnOriginal;   // 원래 상태로 돌아가는 이벤트
	bool isBig = false;

	private void Awake()
	{
		takeDamage = GetComponent<TakeDamage>();
		Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
	}

	private void Update()
	{
		// 여기에 장애물 태그 찾음녀 되는 거 아닌가
	}

	public void NoneDamage()	// 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수
	{
		isBig = true;
		Destroy(takeDamage);    // takedamage 스크립트를 비활성화 시키면 되지않나? - 근데 비활성화하니까 이상하게 돼서 삭제로 해보겠음
		Invoke("OriginalSize", 3f);		// 3초 뒤에 크기 원상태로
		InvokeRepeating("DestroyObstacle", 0f, 0f);
		Invoke("AddTakeDamage", 4f);	// 4초 뒤에 데미지 받는 거 원상태로
	}

	public void OriginalSize()	// 다시 원상태로 돌리기	- Invoke 함수로 아이템 먹을 때 3초 뒤에 호출
	{
		OnOriginal?.Invoke();	// 크기가 줄어드는 애니메이션 추가

		// TODO : 깜빡깜빡 효과도 해야함
	}

	public void AddTakeDamage()
	{
		gameObject.AddComponent<TakeDamage>();      // 다시 TakeDamage 스크립트 추가
	}

	public void DestroyObstacle()	// 장애물 부딪히면 장애물 삭제하기
	{

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			DestroyObstacle();
			Debug.Log("장애물 부딪힘");
		}
	}

	public void CancleHitObstacle()
	{
		CancelInvoke("DestroyObstacle");
		isBig = false;
	}
}

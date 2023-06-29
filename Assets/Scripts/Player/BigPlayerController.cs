using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayerController : MonoBehaviour
{
	// 커지는 아이템을 먹고 플레이어가 커졌을 때 플레이어의 기능 구현
	// 1. 데미지를 받지 않는다 (HP도 안 닳음)
	// 2. 아이템을 오른쪽으로 튕겨냄

	GameObject Obstacle;
	TakeDamage takeDamage;
	public UnityEvent OnOriginal;   // 원래 상태로 돌아가는 이벤트
	bool isBig = false;

	private void Awake()
	{
		takeDamage = GetComponent<TakeDamage>();
		Obstacle = GameObject.FindGameObjectWithTag("Obstacle");
	}

	public void NoneDamage()
	{
		// takedamage 스크립트를 비활성화 시키면 되지않나? - 근데 비활성화하니까 이상하게 돼서 삭제로 해보겠음
		isBig = true;
		Destroy(takeDamage);
		Invoke("OriginalSize", 3f); // 3초 뒤에 원상태로
		//InvokeRepeating("HitObstacle", 0f, 0f);
		//Invoke("HitObstacle", 3f);		// 3초 뒤에 원상태로
		Invoke("AddTakeDamage", 4f);	// 4초 뒤에 원상태로
	}

	public void OriginalSize()	// 다시 원상태로 돌리기	- Invoke 함수로 아이템 먹을 때 3초 뒤에 호출
	{
		OnOriginal?.Invoke();	// 크기가 줄어드는 애니메이션 추가

		// 깜빡깜빡 효과도 해야함
	}

	public void AddTakeDamage()
	{
		gameObject.AddComponent<TakeDamage>();      // 다시 TakeDamage 스크립트 추가
	}

	public void HitObstacle()	// 장애물 부딪히면 튕겨내기
	{
		// 카메라셰이크처럼 랜덤을 이용해서 오른쪽 공간들 중으로 확 이동하도록
		// 오른쪽 ㅣ에서 y축 어디부터~ 어디까지의 공간을 랜덤으로 해놓고 transform.position += 그 위치만큼 이동시키고 1초 뒤에 destroy
		// x는 13. y는 -9 ~ 9까지
		int y = Random.Range(-9, 9);
		// tag가 Obstacle인 오브젝트랑 닿으면 그 오브젝트가 날라감

		Obstacle.transform.position = Vector2.MoveTowards(Obstacle.transform.position, new Vector2(13, y), 0.1f);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 플레이어가 장애물이랑 트리거하면 HitObstacle 호출
		if(col.tag == "Obstacle" && isBig)
		{
			HitObstacle();
			Debug.Log("팅김");
		}
	}

	public void CancleHitObstacle()
	{
		CancelInvoke("HitObstacle");
		isBig = false;
	}
}

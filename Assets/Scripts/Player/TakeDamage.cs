using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	// 데미지를 받을 때!의 상태를 구현해주기
	// 1. 배경이 벌겋게 됨
	// 2. 애니메이션		0
	// 3. 2초간 무적되기	0 + 플레이어 투명화, 깜빡깜빡
	// 4. HP 데미지 깎임	0
	// 5. 카메라 흔들림 1초	0
	// HP가 30% 정도 남으면 배경 벌겋게 깜빡깜빡거림

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
		cameraPos = Camera.main.transform.position;     // 카메라 위치는 시작할 때의 카메라 위치
		mat = sp.material;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 장애물을 통과하면 다치는 애니메이션 실행
		if (col.gameObject.tag == "Obstacle")
		{
			DecreaseHP();   // HP 감소
			OnTakeDamage?.Invoke();
			CameraShake();

			StartCoroutine(IgnoreLayerRoutine());			// 2초 동안 IgnoreLayer 함수를 반복해서 계속 호출
			StartCoroutine(CancleLayerCollisionRoutine());  // 2초 뒤에 Invicibility를 취소시키는 함수 호출
			StartCoroutine(StopCameraShakeRoutine());		// 카메라 흔드는 함수 호출
			//StartCoroutine(PlayerTransparencyRoutine());	// 플레이어 투명화
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator IgnoreLayerRoutine()
	{
		Physics2D.IgnoreLayerCollision(3, 8);           // 장애물 콜라이더(레이어) 무시하기
		yield return new WaitForSeconds(2f);
	}

	IEnumerator CancleLayerCollisionRoutine()
	{
		yield return new WaitForSeconds(2f);
		Physics2D.IgnoreLayerCollision(3, 8, false);    // 다시 레이어 체크
	}

	IEnumerator StopCameraShakeRoutine()
	{
		yield return new WaitForSeconds(0.1f);
		Camera.main.transform.position = cameraPos;		// 카메라 위치 원상복구
	}



	// 플레이어 투명화 하는 거 코루틴으로 0.1초마다 반복하게 하면 되지않낭?
	IEnumerator PlayerTransparencyRoutine()
	{/*
		WaitForSeconds waitsec = new WaitForSeconds(0.2f);
		 
		// 여기서 기본으로 돌아가는거

		for (int i = 0; i < 2; i++)
		{
			PlayerTransparency();
			yield return waitsec;
		}*/

		PlayerTransparency();
		yield return new WaitForSeconds(2f);
	}


	void PlayerTransparency()		// 플레이어 투명화
	{
		Color matColor = mat.color;
		matColor.a = 0.5f;
		mat.color = matColor;
		// 여기서 invoke로 0.1초 뒤에 플레이어 원래 투명도로 돌아오는 함수 호출하기
	}


	void DecreaseHP()
	{
		GameManager.UI.TakeDamageHP(10);	// 10씩 데미지 받으면서 hp가 감소
	}

	void CameraShake()		// 카메라 흔들리기
	{
		float x = Random.Range(0f, 0.8f);
		float y = Random.Range(0f, 0.8f);

		Camera.main.transform.position += new Vector3(x, y, 0);
	}

	void StopCameraShake()	// 카메라 위치 원상태로 복구
	{
		Camera.main.transform.position = cameraPos;
	}
}

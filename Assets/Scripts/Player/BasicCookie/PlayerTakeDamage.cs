using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTakeDamage : MonoBehaviour
{
	Vector3 cameraPos;
	PlayerBase playerBase;

    private void Awake()
    {
        playerBase = GetComponent<PlayerBase>();
    }

    private void Start()
	{
		cameraPos = Camera.main.transform.position;     // 카메라 위치는 시작할 때의 카메라 위치
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		// 장애물을 통과하면 다치는 애니메이션 실행
		if (col.gameObject.tag == "Obstacle")
		{
			GameManager.Data.DecreaseHp(10);

            playerBase.anim.SetTrigger("TakeDamage");

			StartCoroutine(CameraShakeRoutine());			// 카메라 흔드는 함수 호출
			StartCoroutine(IgnoreLayerRoutine());			// 2초 동안 IgnoreLayer 함수를 반복해서 계속 호출
		}
	}

	protected virtual IEnumerator IgnoreLayerRoutine()		// *** 여기서 레이어 무시한 뒤 1.5초 안 지나고 BigItem먹으면 레이어 무시된 채로 이 스크립트 삭제돼서 Destroy안됨 ㅜㅜ
	{
		Physics2D.IgnoreLayerCollision(3, 8, true);           // 장애물 콜라이더(레이어) 무시하기
		yield return new WaitForSeconds(1.5f);
		Physics2D.IgnoreLayerCollision(3, 8, false);    // 다시 레이어 체크
	}

	protected virtual IEnumerator CameraShakeRoutine()
	{
		float x = Random.Range(0f, 0.8f);
		float y = Random.Range(0f, 0.8f);
		Camera.main.transform.position += new Vector3(x, y, 0);
		yield return new WaitForSeconds(0.1f);
		Camera.main.transform.position = cameraPos;		// 카메라 위치 원상복구
	}
}

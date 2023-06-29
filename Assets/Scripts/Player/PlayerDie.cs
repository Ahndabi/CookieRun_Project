using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDie : MonoBehaviour
{
	// HP curHP값이 0이면 Die
	// 죽으면 애니메이션
	// 플레이어 작동 금지
	// 2.5 ~ 3초 뒤에 점수 나옴
	[SerializeField] GameObject[] bg;   // 배경, 바닥
	[SerializeField] GameObject obstacleSpawn;
	public UnityEvent OnDie;

	private void Update()
	{
		if (GameManager.HP.curHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		OnDie?.Invoke();

		for(int i = 0; i < bg.Length; i++)		// 배경 스크롤링 멈춤
		{
			bg[i].GetComponent<BackGround>().enabled = false;
		}

		// 장애물 생성 멈춤
		obstacleSpawn.GetComponent<ObstacleSpawn>().enabled = false;

		// 장애물 이동 멈춤

		// 플레이어 리지드바디 키네마틱으로 설정, 콜라이더는 비활성화
	}
}

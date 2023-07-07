using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDie : MonoBehaviour
{
	// HP curHP값이 0이면 Die
	// 죽으면 애니메이션
	// 플레이어 작동 금지
	// 2.5 ~ 3초 뒤에 점수 나옴
	public UnityEvent OnDie;
	public GameObject DiePlayer;	// 드래그로 씬에 있는 DiePlayer를 넣어줌
	public GameObject Player;
	PlayerInput inputSystem;
	Vector3 cameraPos;

	private void Awake()
	{
		inputSystem = GetComponent<PlayerInput>();
		Player = GameObject.FindWithTag("Player");
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // 시작할 때의 카메라 위치
	}

	private void Update()
	{
		if (GameManager.UI.curHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		StartCoroutine(ShowGameResultUI());

		OnDie?.Invoke();

		// 현재 Player는 비활성화, DiePlayer 활성화
		DiePlayer.SetActive(true);
		Player.SetActive(false);

		// 시간 멈춤. 애니메이션은 Animator에서 Update Mode는 Unscaled Time으로 설정해서 애니메이션만 진행되게 함
		Time.timeScale = 0;
		
		// 카메라 원위치
		Camera.main.transform.position = cameraPos;

		// inputsystem 비활성화. 점프 안되게
		inputSystem.enabled = false;
	}

	IEnumerator ShowGameResultUI()
	{
		yield return new WaitForSeconds(2f);
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameResultUI");
	}
}

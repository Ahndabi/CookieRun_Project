using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDie : MonoBehaviour
{
	// HP curHP값이 0이면 Die
	// 죽으면 애니메이션
	// 플레이어 작동 금지
	// 2.5 ~ 3초 뒤에 점수 나옴
	public GameObject DiePlayer;	// 드래그로 씬에 있는 DiePlayer를 넣어줌
	public GameObject Player;
	Vector3 cameraPos;
	protected PlayerBase playerBase;

	protected virtual void Awake()
	{
        playerBase = GetComponent<PlayerBase>();
        Player = GameObject.FindWithTag("Player");
	}

	private void Start()
	{
        cameraPos = Camera.main.transform.position;     // 시작할 때의 카메라 위치
		StartCoroutine(CheckDieRoutine());
    }


    public virtual IEnumerator CheckDieRoutine()
	{
		while (true)
        {
            if (GameManager.Data.HP <= 0)
            {
                Die();
            }
			yield return null;
        }
	}

	protected virtual void Die()
	{
		StartCoroutine(ShowGameResultUI());

		// 시간 멈춤. 애니메이션은 Animator에서 Update Mode는 Unscaled Time으로 설정해서 애니메이션만 진행되게 함
		Time.timeScale = 0;
		
		// 카메라 원위치
		Camera.main.transform.position = cameraPos;

		// inputsystem 비활성화. 점프 안되게
		playerBase.anim.enabled = true;
		playerBase.inputSystem.enabled = false;

        // 현재 Player는 비활성화, DiePlayer 활성화
        DiePlayer.SetActive(true);
        Player.SetActive(false);
    }

	protected IEnumerator ShowGameResultUI()
	{
		yield return new WaitForSeconds(2f);
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameResultUI");
	}
}

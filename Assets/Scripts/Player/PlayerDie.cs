using System.Collections;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    // HP curHP값이 0이면 Die
    // 죽으면 애니메이션
    // 플레이어 작동 금지
    // 2.5 ~ 3초 뒤에 점수 나옴

    [SerializeField] protected PlayerBase playerBase;       // diePlayer의 playerBase를 넣어줌
	protected IEnumerator resultUICor = null;
	Vector3 cameraPos;
	// AudioClip dieSound;

	private void Awake()
	{
		//dieSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GameEnd");
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // 시작할 때의 카메라 위치
		PlayerBase.isDie = false;
	}

	public virtual void Die()
	{
		// 시간 멈춤. 
		Time.timeScale = 0;
		
		// 카메라 원위치
		Camera.main.transform.position = cameraPos;

        // 애니메이션은 Animator에서 Update Mode는 Unscaled Time으로 설정해서 애니메이션만 진행되게 함
        playerBase.anim.updateMode = AnimatorUpdateMode.UnscaledTime;
		playerBase.anim.SetTrigger("IsDie");

		playerBase.isUnDamage = true;
		PlayerBase.isDie = true;

		resultUICor = ShowGameResultUI();
		StartCoroutine(resultUICor);
    }

    protected IEnumerator ShowGameResultUI()
	{
		yield return new WaitForSecondsRealtime(2f);

		GameManager.UI.ShowResultUI();
    }
}

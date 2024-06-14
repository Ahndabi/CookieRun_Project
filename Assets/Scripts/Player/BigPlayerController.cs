using System.Collections;
using UnityEngine;

public class BigPlayerController : MonoBehaviour, IBiggable
{
    [SerializeField] PlayerBase playerBase;
	TakeDamage takeDamage;
	bool isBig = false;

	public void NoneDamage()	// 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수
	{
        isBig = true;
        playerBase.isUnDamage = true;
		StartCoroutine(OriginalSizeRoutine());
		
	}

	IEnumerator OriginalSizeRoutine()
	{
		yield return new WaitForSeconds(3f);
        playerBase.anim.SetTrigger("Smaller");     // 원래 상태로 돌아감 (작아짐)
		isBig = false;
		playerBase.isUnDamage = false;

		// TODO : 깜빡깜빡 효과도 추가해야함
	}


	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			Destroy(col.gameObject);		// 부딪힌 장애물은 Destroy
		}
	}

}

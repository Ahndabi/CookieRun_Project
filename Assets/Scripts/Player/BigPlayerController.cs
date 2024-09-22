using System.Collections;
using UnityEngine;

public class BigPlayerController : MonoBehaviour, IBiggable
{
    [SerializeField] PlayerBase playerBase;
    static readonly int Smaller_animation = Animator.StringToHash("Smaller");
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
        playerBase.anim.SetTrigger(Smaller_animation);     // 원래 상태로 돌아감 (작아짐)
		isBig = false;

        StartCoroutine(FlickerPlayerRoutine());
	}

	IEnumerator FlickerPlayerRoutine()	// 작아질 때 깜빡깜빡 거리는 코루틴
	{
        float time = 0;
        bool isUp = false;  // 투명도 올리는 bool
        float colorA = 1;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        while (time < 3)
        {
            time += Time.deltaTime;

            if (isUp == false)
            {
                colorA -= 0.02f;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, colorA);
                if (colorA < 0.1f)
                {
                    isUp = true;
                }
            }
            else if (isUp == true)
            {
                colorA += 0.02f;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, colorA);

                if (colorA > 0.8f)
                {
                    isUp = false;
                }
            }
            yield return null;
        }
        
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        playerBase.isUnDamage = false;
    }


	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Obstacle" && isBig)
		{
			Destroy(col.gameObject);		// 부딪힌 장애물은 Destroy
		}
	}
}

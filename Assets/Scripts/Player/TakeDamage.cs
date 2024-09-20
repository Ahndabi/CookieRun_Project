using System.Collections;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // 데미지를 받을 때!의 상태를 구현해주기
    // 1. 배경이 벌겋게 됨
    // 2. 애니메이션		0
    // 3. 2초간 무적되기	0 + 플레이어 투명화, 깜빡깜빡
    // 4. HP 데미지 깎임	0
    // 5. 카메라 흔들림 1초	0
    // HP가 30% 정도 남으면 배경 벌겋게 깜빡깜빡거림

    [SerializeField] PlayerBase playerBase;
    Vector3 cameraPos;

    private void Start()
    {
        cameraPos = Camera.main.transform.position;     // 카메라 위치는 시작할 때의 카메라 위치
        playerBase.isUnDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 장애물을 통과하면 다치는 애니메이션 실행
        if (col.gameObject.tag == "Obstacle" && playerBase.isUnDamage == false)
        {
            if (PlayerBase.isDie == false)
            {
                StartCoroutine(CameraShakeRoutine());           // 카메라 흔드는 함수 호출
                StartCoroutine(DontTakeDamageRoutine());           // 2초 동안 IgnoreLayer 함수를 반복해서 계속 호출

                DecreaseHP();   // HP 감소

                playerBase.anim.SetTrigger("TakeDamage");

            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DontTakeDamageRoutine()
    {
        playerBase.isUnDamage = true;

        float time = 0;
        bool isUp = false;  // 투명도 올리는 bool
        float colorA = 1;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        while (time < 1.5f)
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

    IEnumerator CameraShakeRoutine()
    {
        float x = Random.Range(0f, 0.8f);
        float y = Random.Range(0f, 0.8f);
        Camera.main.transform.position += new Vector3(x, y, 0);
        yield return new WaitForSeconds(0.1f);
        Camera.main.transform.position = cameraPos;     // 카메라 위치 원상복구
    }


    void DecreaseHP()
    {
        GameManager.UI.TakeDamageHP(10);    // 10씩 데미지 받으면서 hp가 감소
        if (GameManager.UI.curHP <= 0)
        {
            gameObject.GetComponent<PlayerDie>().Die();
        }
    }
}
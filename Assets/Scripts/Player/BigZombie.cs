using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : PlayerBase, IBiggable
{
    [SerializeField] ZombieTakeDamage zombieTakeDamage;
    bool isBig = false;

    void IBiggable.NoneDamage()     // 커지는 애니메이션 이벤트로 붙일 함수
    {
        zombieTakeDamage = GetComponent<ZombieTakeDamage>();
        isBig = true;
        Destroy(zombieTakeDamage);
        StartCoroutine(OriginalSizeRoutine());
        StartCoroutine(AddTakeDamageRoutine());
    }

    IEnumerator OriginalSizeRoutine()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Smaller");    // 원래 상태로 돌아감 (작아짐)
        isBig = false;
    }

    protected virtual IEnumerator AddTakeDamageRoutine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.AddComponent<ZombieTakeDamage>();      // 다시 TakeDamage 스크립트 추가
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle" && isBig)
        {
            Destroy(col.gameObject);        // 부딪힌 장애물은 Destroy
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IBiggable     // 아이템을 먹고 커질 수 있는 인터페이스
{
    protected void NoneDamage();    // 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수

    /* 원래 BigPlayer에 있던 내용
     * 
    TakeDamage takeDamage;
    Animator anim;
    bool isBig = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void NoneDamage() // 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수
    {
        takeDamage = GetComponent<TakeDamage>();
        isBig = true;
        Destroy(takeDamage);
        StartCoroutine(OriginalSizeRoutine());
        StartCoroutine(AddTakeDamageRoutine());
    }

    IEnumerator OriginalSizeRoutine()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Smaller");     // 원래 상태로 돌아감 (작아짐)
        isBig = false;
    }

    protected virtual IEnumerator AddTakeDamageRoutine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.AddComponent<TakeDamage>();      // 다시 TakeDamage 스크립트 추가
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle" && isBig)
        {
            Destroy(col.gameObject);        // 부딪힌 장애물은 Destroy
        }
    }*/
}

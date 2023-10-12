using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayer : PlayerBase, IBiggable
{
    TakeDamage takeDamage;
    bool isBig = false;
    
    void IBiggable.NoneDamage()
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
    }
}

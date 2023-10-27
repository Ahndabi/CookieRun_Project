using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigPlayer : MonoBehaviour, IBiggable
{
    PlayerTakeDamage takeDamage;
    protected bool isBig = false;
    PlayerBase playerBase;

    private void Awake()
    {
        playerBase = GetComponent<PlayerBase>();
    }

    void IBiggable.NoneDamage()
    {
        takeDamage = GetComponent<PlayerTakeDamage>();
        isBig = true;
        Destroy(takeDamage);
        StartCoroutine(OriginalSizeRoutine());
        StartCoroutine(AddTakeDamageRoutine());
    }

    IEnumerator OriginalSizeRoutine()
    {
        yield return new WaitForSeconds(3f);
        playerBase.anim.SetTrigger("Smaller");     // 원래 상태로 돌아감 (작아짐)
        isBig = false;
    }

    protected virtual IEnumerator AddTakeDamageRoutine()
    {
        yield return new WaitForSeconds(4f);

        gameObject.AddComponent<PlayerTakeDamage>();      // 다시 TakeDamage 스크립트 추가
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Obstacle" && isBig)
        {
            Destroy(col.gameObject);        // 부딪힌 장애물은 Destroy
        }
    }

}

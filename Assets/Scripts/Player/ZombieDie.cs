using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDie : PlayerDie
{
    // 좀비는 한 번 죽으면 짧은 체력으로 부활하는 기능이 있음
    bool oneDie = false;

    public override void Die()
    {
        base.Die();

        // 부활 가능한 상태라면
        if (oneDie == false)
        {
            StopCoroutine(resultUICor);
            StartCoroutine(DontTakeDamageRoutine());
            // SpawnZombie();
            StartCoroutine(SpawnZombieRoutine());
            oneDie = true;
        }
    }

    IEnumerator SpawnZombieRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        PlayerBase.isDie = false;

        Time.timeScale = 1f;
        GameManager.UI.curHP = GameManager.UI.maxHP;
        playerBase.anim.Play("Move");
    }

    void SpawnZombie()
    {
        PlayerBase.isDie = false;

        Time.timeScale = 1f;
        GameManager.UI.curHP = GameManager.UI.maxHP;
        playerBase.anim.Play("Move");
    }

    // 부활하고 난 직후 데미지를 받지 않는 코루틴
    IEnumerator DontTakeDamageRoutine()
    {
        float elapedTime = 0;
        playerBase.isUnDamage = true;

        while (elapedTime < 2)
        {
            elapedTime += Time.deltaTime;
            playerBase.isUnDamage = true;

            yield return null;
        }
        playerBase.isUnDamage = false;
    }

}

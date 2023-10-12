using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieDie : PlayerDie
{
    bool oneDie = false;

    private void OnDisable()
    {
        StopCoroutine(CheckDieRoutine());
    }

    protected override void Die()
    {
        base.Die();

        if (oneDie)
        {
            return;
        }
        else if (!oneDie)    // oneDie가 false일 경우
        {
            oneDie = true;
            Player.SetActive(true);
            DiePlayer.SetActive(false);
            anim.SetTrigger("IsDie");
            Debug.Log("override Die");
        }
    }

    public void ZombieSpawn()      // Spawn 애니메이션이 끝날 때 붙여줄 이벤트
    {
        GameManager.Data.ZombieSpawnHp();

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

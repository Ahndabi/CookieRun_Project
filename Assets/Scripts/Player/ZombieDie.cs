using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieDie : PlayerDie
{
    bool oneDie = false;

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
        }
    }

    public void ZombieSpawn()      // Spawn 애니메이션이 끝날 때 붙여줄 이벤트
    {
        // TODO : HP가 30으로 변경

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

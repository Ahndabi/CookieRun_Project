using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieDie : PlayerDie
{
    bool oneDie = false;

    protected override IEnumerator CheckDieRoutine()
    {
        while (true)
        {
            if (GameManager.Data.HP <= 0)
            {
                Die();
            }
            yield return null;
        }
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
            Debug.Log("!oneDie");
        }
    }

    public void ZombieSpawn()      // Spawn 애니메이션이 끝날 때 붙여줄 이벤트
    {
        // TODO : HP가 30으로 변경

        Time.timeScale = 1.0f;

        // StopCorutine(점수UI나오는 코루틴) 멈춰
        StopCoroutine(ShowGameResultUI());
        Debug.Log("부활");
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

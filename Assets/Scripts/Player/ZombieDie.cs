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
        else if (!oneDie)    // oneDie�� false�� ���
        {
            oneDie = true;
            Player.SetActive(true);
            DiePlayer.SetActive(false);
            anim.SetTrigger("IsDie");
            Debug.Log("override Die");
        }
    }

    public void ZombieSpawn()      // Spawn �ִϸ��̼��� ���� �� �ٿ��� �̺�Ʈ
    {
        GameManager.Data.ZombieSpawnHp();

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

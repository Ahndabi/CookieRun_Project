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
        else if (!oneDie)    // oneDie�� false�� ���
        {
            oneDie = true;
            Player.SetActive(true);
            DiePlayer.SetActive(false);
            anim.SetTrigger("IsDie");
        }
    }

    public void ZombieSpawn()      // Spawn �ִϸ��̼��� ���� �� �ٿ��� �̺�Ʈ
    {
        // TODO : HP�� 30���� ����

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

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
        else if (!oneDie)    // oneDie�� false�� ���
        {
            oneDie = true;
            Player.SetActive(true);
            DiePlayer.SetActive(false);
            anim.SetTrigger("IsDie");
            Debug.Log("!oneDie");
        }
    }

    public void ZombieSpawn()      // Spawn �ִϸ��̼��� ���� �� �ٿ��� �̺�Ʈ
    {
        // TODO : HP�� 30���� ����

        Time.timeScale = 1.0f;

        // StopCorutine(����UI������ �ڷ�ƾ) ����
        StopCoroutine(ShowGameResultUI());
        Debug.Log("��Ȱ");
        inputSystem.enabled = true;
        anim.SetTrigger("Move");
    }
}

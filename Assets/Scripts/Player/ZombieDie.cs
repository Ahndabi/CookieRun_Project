using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieDie : PlayerDie
{
    bool oneDie = false;
    PlayerTakeDamage takeDamage;
    
    private void Awake()
    {
        base.Awake();
        
        takeDamage = GetComponent<PlayerTakeDamage>();
    }
    
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
            playerBase.anim.SetTrigger("IsDie");
        }
    }
    
    public void ZombieSpawn()      // Spawn �ִϸ��̼��� ���� �� �ٿ��� �̺�Ʈ
    {
        StartCoroutine(NoTakeDamageRoutine());
        GameManager.Data.ZombieSpawnHp();

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        playerBase.inputSystem.enabled = true;
        playerBase.anim.SetTrigger("Move");
    }

    IEnumerator NoTakeDamageRoutine()   // �������� 2�� ���� ���� �ʴ� �Լ�
    {
        Destroy(takeDamage);
        yield return new WaitForSeconds(2f);
        gameObject.AddComponent<PlayerTakeDamage>();
        Physics2D.IgnoreLayerCollision(3, 8, false);    // �ٽ� ���̾� üũ
    }
}

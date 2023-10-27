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
        else if (!oneDie)    // oneDie가 false일 경우
        {
            oneDie = true;
            Player.SetActive(true);
            DiePlayer.SetActive(false);
            playerBase.anim.SetTrigger("IsDie");
        }
    }
    
    public void ZombieSpawn()      // Spawn 애니메이션이 끝날 때 붙여줄 이벤트
    {
        StartCoroutine(NoTakeDamageRoutine());
        GameManager.Data.ZombieSpawnHp();

        Time.timeScale = 1.0f;

        StopCoroutine(ShowGameResultUI());
        playerBase.inputSystem.enabled = true;
        playerBase.anim.SetTrigger("Move");
    }

    IEnumerator NoTakeDamageRoutine()   // 데미지를 2초 동안 받지 않는 함수
    {
        Destroy(takeDamage);
        yield return new WaitForSeconds(2f);
        gameObject.AddComponent<PlayerTakeDamage>();
        Physics2D.IgnoreLayerCollision(3, 8, false);    // 다시 레이어 체크
    }
}

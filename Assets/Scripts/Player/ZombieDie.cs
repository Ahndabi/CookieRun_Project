using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDie : PlayerDie
{
    bool oneSpawn = false;


    protected override IEnumerator CheckDieRoutine()
    {
        return base.CheckDieRoutine();

        
    }

    
    void ZombieSpawn()      // oneSpawn�� false �� ȣ��� �Լ�
    {
        // StopCorutine(����UI������ �ڷ�ƾ)
        StopCoroutine(ShowGameResultUI());

        // DiePlayer�� ��Ȱ �ִϸ��̼��� trigger�� ����. GetCurrentAnimatorStateInfo(0).length �� ����ϸ� ���� ��� ���� �ִϸ��̼� ����ð��� �� �� ����.
        // �׷��� Corutine�� �� ����ð� ��ŭ�� ����ǵ���! ��. �׷��� ��Ȱ �ִϸ��̼Ǹ� ������ �ð��� ���ߵ���.
        // �ڷ�ƾ �ð��� ������ Time.timeSacle = 1f;
        
        // gameObejct.Ȱ��ȭ -> ���� �� ������Ʈ�� LivePlayer��
        // DiePlayer.SetActive(false);
        // Hp�� 30���� ����. -> Hp �����ϴ� Ŭ�������� HP 30���� ���ִ� �Լ��� ���� �̰� ȣ��

    }

    IEnumerator SpawnAnimationRoutine()
    {
        yield return null;

    }

    // if (��Ȱ �� �� ������ return)
    // if (��Ȱ �� ���� �� ������)
    // ü�� 30���� �ٽ� ��Ƴ�.
    // -> �ٽ� �� ���ӿ�����Ʈ Ȱ��ȭ. 
}

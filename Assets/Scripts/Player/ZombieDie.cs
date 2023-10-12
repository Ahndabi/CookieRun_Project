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

    
    void ZombieSpawn()      // oneSpawn이 false 면 호출될 함수
    {
        // StopCorutine(점수UI나오는 코루틴)
        StopCoroutine(ShowGameResultUI());

        // DiePlayer에 부활 애니메이션을 trigger로 실행. GetCurrentAnimatorStateInfo(0).length 를 사용하면 현재 재생 중인 애니메이션 재생시간을 알 수 있음.
        // 그래서 Corutine을 저 재생시간 만큼만 실행되도록! 함. 그래서 부활 애니메이션만 나오는 시간에 맞추도록.
        // 코루틴 시간이 끝나면 Time.timeSacle = 1f;
        
        // gameObejct.활성화 -> 지금 이 오브젝트는 LivePlayer임
        // DiePlayer.SetActive(false);
        // Hp는 30으로 변경. -> Hp 관리하는 클래스에서 HP 30으로 해주는 함수를 만들어서 이거 호출

    }

    IEnumerator SpawnAnimationRoutine()
    {
        yield return null;

    }

    // if (부활 한 번 했으면 return)
    // if (부활 한 번도 안 했으면)
    // 체력 30으로 다시 살아남.
    // -> 다시 이 게임오브젝트 활성화. 
}

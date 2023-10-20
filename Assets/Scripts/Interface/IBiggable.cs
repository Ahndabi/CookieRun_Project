using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IBiggable     // 아이템을 먹고 커질 수 있는 인터페이스
{
    protected void NoneDamage();    // 플레이어가 커지는 애니메이션에 이벤트로 붙인 함수
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseCookiePopUpUI : WindowUI
{
    private void Awake()
    {
        base.Awake();

        // buttons["ChooseBraveCookieButton"].onClick.AddListener(EnableChoosedBraveCookie);
        // buttons["ChooseZombieCookieButton"].onClick.AddListener(EnableChoosedZombieCookie);
        buttons["ChooseBraveCookieButton"].onClick.AddListener(() => ChoosedCookies.OnChoosedBraveCookie?.Invoke());
        buttons["ChooseZombieCookieButton"].onClick.AddListener(() => ChoosedCookies.OnChoosedZombieCookie?.Invoke());
    }


    void EnableChoosedBraveCookie()     // 용감한 쿠키선택 시 선택됐다는 ui 활성화
    {
        images["ChooseBraveCookie"].enabled = false;
    }


    void EnableChoosedZombieCookie()    // 좀비 쿠키선택 시 선택됐다는 ui 활성화
    {
        images["ChooseZombieCookie"].enabled = false;
    }

}

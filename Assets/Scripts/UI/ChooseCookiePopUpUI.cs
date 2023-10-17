using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseCookiePopUpUI : WindowUI
{
    private void Awake()
    {
        base.Awake();

        buttons["ChooseBraveCookieButton"].onClick.AddListener(() => ChoosedCookies.OnChoosedBraveCookie?.Invoke());
        buttons["ChooseZombieCookieButton"].onClick.AddListener(() => ChoosedCookies.OnChoosedZombieCookie?.Invoke());
    }
}

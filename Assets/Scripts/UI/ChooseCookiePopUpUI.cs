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


    void EnableChoosedBraveCookie()     // �밨�� ��Ű���� �� ���õƴٴ� ui Ȱ��ȭ
    {
        images["ChooseBraveCookie"].enabled = false;
    }


    void EnableChoosedZombieCookie()    // ���� ��Ű���� �� ���õƴٴ� ui Ȱ��ȭ
    {
        images["ChooseZombieCookie"].enabled = false;
    }

}

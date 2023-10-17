using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoosedCookies : MonoBehaviour
{
    public static UnityEvent OnChoosedZombieCookie = new UnityEvent();    // 선택된 쿠키로 게임을 진행해야 하니 그것을 알려줄 이벤트
    public static UnityEvent OnChoosedBraveCookie = new UnityEvent();    // 선택된 쿠키로 게임을 진행해야 하니 그것을 알려줄 이벤트

    [SerializeField] GameObject zombieCookie;
    [SerializeField] GameObject braveCookie;

    private void OnEnable()
    {
        OnChoosedZombieCookie.AddListener(ChoosedZombieCookie);
        OnChoosedBraveCookie.AddListener(ChoosedBraveCookie);
    }

    public void ChoosedZombieCookie()
    {
        zombieCookie.SetActive(true);
        braveCookie.SetActive(false);
    }

    public void ChoosedBraveCookie()
    {
        zombieCookie.SetActive(false);
        braveCookie.SetActive(true);
    }
}

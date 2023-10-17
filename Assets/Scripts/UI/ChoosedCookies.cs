using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoosedCookies : MonoBehaviour
{
    public static UnityEvent OnChoosedZombieCookie = new UnityEvent();    // ���õ� ��Ű�� ������ �����ؾ� �ϴ� �װ��� �˷��� �̺�Ʈ
    public static UnityEvent OnChoosedBraveCookie = new UnityEvent();    // ���õ� ��Ű�� ������ �����ؾ� �ϴ� �װ��� �˷��� �̺�Ʈ
    private static int zombieCookieNumber = 0;
    public static int ZombieCookieNumber { get { return zombieCookieNumber; } set { value = zombieCookieNumber; } }
    private static int braveCookieNumber = 0;
    public static int BraveCookieNumber { get { return braveCookieNumber; } set { value = braveCookieNumber; } }


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
        zombieCookieNumber = 2;
    }

    public void ChoosedBraveCookie()
    {
        zombieCookie.SetActive(false);
        braveCookie.SetActive(true);
        braveCookieNumber = 1;
    }
}

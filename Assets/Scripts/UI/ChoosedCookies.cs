using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoosedCookies : MonoBehaviour
{
    public static UnityEvent OnChoosedZombieCookie = new UnityEvent();    // ���õ� ��Ű�� ������ �����ؾ� �ϴ� �װ��� �˷��� �̺�Ʈ
    public static UnityEvent OnChoosedBraveCookie = new UnityEvent();    // ���õ� ��Ű�� ������ �����ؾ� �ϴ� �װ��� �˷��� �̺�Ʈ

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

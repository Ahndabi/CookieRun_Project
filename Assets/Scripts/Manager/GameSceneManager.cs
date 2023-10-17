using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // �κ��, ���Ӿ��� ����. ���⼱ ���Ӿ��� ���ؼ��� ����

    private void OnEnable()
    {
        if (ChoosedCookies.BraveCookieNumber == 1)
        {
            EnablBraveCookie();
            ChoosedCookies.BraveCookieNumber = 0;
        }
        else if (ChoosedCookies.ZombieCookieNumber == 2)
        {
            EnableZombieCookie();
            ChoosedCookies.ZombieCookieNumber = 0;
        }
        else
        {
            return;
        }
    }

    private void OnDisable()
    {
        ChoosedCookies.BraveCookieNumber = 0;
        ChoosedCookies.ZombieCookieNumber = 0;
    }

    public void StartGameScene()	// ���ӽ��� ������ �Ѿ ���� �Լ�
	{
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1;
	}

	public void EnableZombieCookie()
	{
		GameObject.Find("AllZombieCookie").SetActive(true);
		GameObject.Find("AllBraveCookie").SetActive(false);
	}

    public void EnablBraveCookie()
    {
        GameObject.Find("AllZombieCookie").SetActive(false);
        GameObject.Find("AllBraveCookie").SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // 로비씬, 게임씬이 있음. 여기선 게임씬에 대해서만 구현

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

    public void StartGameScene()	// 게임시작 씬으로 넘어갈 때의 함수
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

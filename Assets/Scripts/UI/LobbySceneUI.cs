using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
	private void Awake()
	{
		base.Awake();

		buttons["StartButton"].onClick.AddListener(() => { GameScene(); });
		buttons["ChooseCookieButton"].onClick.AddListener(() => { GameManager.UI.ShowWindowUI<WindowUI>("UI/ChooseCookiePopUpUI"); });
	}

	void GameScene()    // 게임 씬으로 넘어가는 함수
    {
		GameManager.Scene.StartGameScene();
    }

    void ChooseCookiePopUpUI()		// 쿠키 선택 창으로 넘어가는 함수
	{
		Debug.Log("쿠키 선택 창");
	}
}

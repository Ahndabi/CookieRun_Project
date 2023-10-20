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
		buttons["ChooseCookieButton"].onClick.AddListener(() => { GameManager.UI.ShowWindowUI<WindowUI>("UI/ChooseCookieWindowUI"); });
	}

	void GameScene()    // ���� ������ �Ѿ�� �Լ�
    {
		GameManager.Scene.StartGameScene();
    }
}

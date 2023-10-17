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

	void GameScene()    // ���� ������ �Ѿ�� �Լ�
    {
		GameManager.Scene.StartGameScene();
    }

    void ChooseCookiePopUpUI()		// ��Ű ���� â���� �Ѿ�� �Լ�
	{
		Debug.Log("��Ű ���� â");
	}
}

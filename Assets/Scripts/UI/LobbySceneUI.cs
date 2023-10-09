using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
	GameObject Player;

	private void Awake()
	{
		base.Awake();

		Player = GameManager.Resource.Load<GameObject>("Prefabs/Player");
		buttons["StartButton"].onClick.AddListener(() => { GameScene(); });
	}

	// ���� ������ �Ѿ�� �Լ�
	void GameScene()
	{
		GameManager.Scene.StartGameScene();
	}
}

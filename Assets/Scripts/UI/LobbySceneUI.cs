using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
	private void Awake()
	{
		base.Awake();

		buttons["StartButton"].onClick.AddListener(() => { GameScene(); });
	}

	// 게임 씬으로 넘어가는 함수
	void GameScene()
	{
		//SceneManager.LoadScene("GameScene");
		// TODO : 게임 씬으로 넘어갈 때 초기 상태로 초기화해줘야 함! 두 번 플레이하면 플레이어 죽는 그 상태로 다시 되돌아와,,
	}
}

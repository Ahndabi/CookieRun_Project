using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultUI : PopUpUI
{
	// 플레이어 죽고 먹은 젤리, 코인 개수 나오는 점수판 UI

	private void Awake()
	{
		base.Awake();

		texts["JellyScoreText"].text = GameManager.Data.JellyCount.ToString();
		texts["CoinScoreText"].text = GameManager.Data.CoinCount.ToString();
		buttons["OKButton"].onClick.AddListener(() => { ChangedLobbyScene(); }) ;
	}
	
	void ChangedLobbyScene()
	{
		SceneManager.LoadScene("LobbyScene");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultUI : PopUpUI
{
	// 플레이어 죽고 먹은 젤리, 코인 개수 나오는 점수판 UI

	// GameResultUI가 활성화 되면서 << 이거는 PlayerDie에서 해야 될 일 가튼뎅
	// JellyScoreText 는 현재 JellyCount가 되고
	// CoinScoreText 는 현재 CoinCount가 됨.
	// OkButton을 누르면 로비 씬으로 감

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

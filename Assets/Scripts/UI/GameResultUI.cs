using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultUI : PopUpUI
{
	// �÷��̾� �װ� ���� ����, ���� ���� ������ ������ UI

	// GameResultUI�� Ȱ��ȭ �Ǹ鼭 << �̰Ŵ� PlayerDie���� �ؾ� �� �� ��ư��
	// JellyScoreText �� ���� JellyCount�� �ǰ�
	// CoinScoreText �� ���� CoinCount�� ��.
	// OkButton�� ������ �κ� ������ ��

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

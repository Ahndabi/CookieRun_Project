using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
}

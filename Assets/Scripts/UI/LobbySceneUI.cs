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

	// ���� ������ �Ѿ�� �Լ�
	void GameScene()
	{
		//SceneManager.LoadScene("GameScene");
		// TODO : ���� ������ �Ѿ �� �ʱ� ���·� �ʱ�ȭ����� ��! �� �� �÷����ϸ� �÷��̾� �״� �� ���·� �ٽ� �ǵ��ƿ�,,
	}
}

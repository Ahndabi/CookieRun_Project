using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	// �κ��, ���Ӿ��� ����. ���⼱ ���Ӿ��� ���ؼ��� ����

	public void StartGameScene()	// ���ӽ��� ������ �Ѿ ���� �Լ�
	{
		SceneManager.LoadScene("GameScene");
		GameManager.UI.curHP = GameManager.UI.maxHP;
		Time.timeScale = 1;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	// 로비씬, 게임씬이 있음. 여기선 게임씬에 대해서만 구현

    public void StartGameScene()	// 게임시작 씬으로 넘어갈 때의 함수
	{
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1;
	}
}

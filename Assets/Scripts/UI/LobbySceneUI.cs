using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        // buttons["StartButton"].onClick.AddListener(() => { GameScene(); });
        buttons["StartButton"].onClick.AddListener(() => { LoadGameScene(); });
        buttons["SelectButton"].onClick.AddListener( () => { LoadSelectPlayerScene(); });
    }

    // 게임 씬으로 넘어가는 함수
    void LoadGameScene()
	{
        SceneManager.LoadScene(2);
		//GameManager.Scene.StartGameScene();
	}

    // 캐릭터 선택 씬으로 넘어가는 함수
    void LoadSelectPlayerScene()
    {
        SceneManager.LoadScene(1);
    }
}

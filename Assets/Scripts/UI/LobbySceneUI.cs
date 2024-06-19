using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : SceneUI
{
    [SerializeField] GameObject selectPlayerUI;

    protected override void Awake()
    {
        base.Awake();

        buttons["StartButton"].onClick.AddListener(() => { LoadGameScene(); });
        buttons["SelectButton"].onClick.AddListener( () => { LoadSelectPlayerScene(); });
    }

    // 게임 씬으로 넘어가는 함수
    void LoadGameScene()
	{
        SceneManager.LoadScene(1);
	}

    // 캐릭터 팝업 띄우는 함수
    void LoadSelectPlayerScene()
    {
        selectPlayerUI.SetActive(true);
    }
}

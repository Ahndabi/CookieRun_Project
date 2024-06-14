using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        // buttons["StartButton"].onClick.AddListener(() => { GameScene(); });
        buttons["BasicPlayerButton"].onClick.AddListener(() => { OnClickBasicPlayerBtn(); });
        buttons["ZombiePlayerButton"].onClick.AddListener(() => { OnClickZombiePlayerBtn(); });
        buttons["GameStartButton"].onClick.AddListener(() => { OnClickGameStartBtn(); });
    }

    void OnClickGameStartBtn()
    {
        SceneManager.LoadScene(2);
    }

    // 기본 캐릭터 선택할 시
    void OnClickBasicPlayerBtn()
    {
        GameManager.Data.currentPlayer = Players.BasicPlayer;
        // 기본 캐릭터 창 활성화
        // 클릭된 버튼 활성화
        // 클릭할 버튼 비활성화
        // 좀비 캐릭터 창 비활성화
    }

    void OnClickZombiePlayerBtn()
    {
        GameManager.Data.currentPlayer = Players.ZombiePlayer;
        // 기본 캐릭터 창 비활성화
        // 좀비 캐릭터 창 활성화
        // 클릭된 버튼 활성화
        // 클릭할 버튼 비활성화
    }
}

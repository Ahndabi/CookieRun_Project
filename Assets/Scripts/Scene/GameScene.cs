using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : BaseScene
{
    // 로비씬, 게임씬이 있음. 여기선 게임씬에 대해서만 구현

    [SerializeField] GameObject playerPrefab;

    protected override void Init()
    {
        base.Init();

        Time.timeScale = 1f;
        GameManager.UI.curHP = GameManager.UI.maxHP;
        GameManager.Data.DecidePlayer();
        CreatePlayer();
    }

    void CreatePlayer()
    {
        Instantiate(GameManager.Data.player, playerPrefab.transform);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerSceneUI : SceneUI
{
    [SerializeField] Image electiveZombieImg;   // 선택할 수 있는 좀비 img
    [SerializeField] Image checkedZombieImg;    // 선택된 좀비 img  
    [SerializeField] Image electiveBasicImg;    // 선택할 수 있는 기본 img
    [SerializeField] Image checkedBasicImg;     // 선택된 기본 img
    [SerializeField] GameObject selectPlayerUI;

    protected override void Awake()
    {
        base.Awake();
        buttons["CheckZombieBtn"].onClick.AddListener(() => { OnClickZombiePlayerBtn(); });
        buttons["CheckBasicBtn"].onClick.AddListener(() => { OnClickBasicPlayerBtn(); });
        buttons["BackBtn"].onClick.AddListener(() => { OnClickBackBtn(); });
    }

    // 기본 캐릭터 선택하는 버튼
    void OnClickBasicPlayerBtn()
    {
        GameManager.Data.currentPlayer = Players.BasicPlayer;
        electiveBasicImg.gameObject.SetActive(false);
        checkedBasicImg.gameObject.SetActive(true);
        electiveZombieImg.gameObject.SetActive(true);
        checkedZombieImg.gameObject.SetActive(false);
        // 기본 캐릭터 창 활성화
        // 클릭된 버튼 활성화
        // 클릭할 버튼 비활성화
        // 좀비 캐릭터 창 비활성화
    }

    // 좀비 선택 버튼
    void OnClickZombiePlayerBtn()
    {
        GameManager.Data.currentPlayer = Players.ZombiePlayer;

        electiveBasicImg.gameObject.SetActive(true);
        checkedBasicImg.gameObject.SetActive(false);
        electiveZombieImg.gameObject.SetActive(false);
        checkedZombieImg.gameObject.SetActive(true);
        // 기본 캐릭터 창 비활성화
        // 좀비 캐릭터 창 활성화
        // 클릭된 버튼 활성화
        // 클릭할 버튼 비활성화
    }

    void OnClickBackBtn()
    {
        selectPlayerUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    // 로비에서 UI들 활성화, 비활성화 관리

    [SerializeField] LobbySceneUI lobbySceneUI;
    [SerializeField] ChooseCookiePopUpUI lobbyChooseCookiePopUpUI;
    [SerializeField] ChoosedCookies choosedCookies;

    public void ChooseCookiePopUpUI()   // 쿠키 버튼 누르면 뜨는 쿠키 선택 리스트 창
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ChooseCookiePopUpUI");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    // �κ񿡼� UI�� Ȱ��ȭ, ��Ȱ��ȭ ����

    [SerializeField] LobbySceneUI lobbySceneUI;
    [SerializeField] ChooseCookiePopUpUI lobbyChooseCookiePopUpUI;
    [SerializeField] ChoosedCookies choosedCookies;

    public void ChooseCookiePopUpUI()   // ��Ű ��ư ������ �ߴ� ��Ű ���� ����Ʈ â
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ChooseCookiePopUpUI");
    }
}

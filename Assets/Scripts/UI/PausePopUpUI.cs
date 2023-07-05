using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PausePopUpUI : SceneUI		// �Ͻ����� UI�� Scene�� �ִ� �Ŷ� SceneUI ��ӹ���
{
	PlayerController playerController;

	protected override void Awake()
	{
		base.Awake();

		buttons["PauseButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		Debug.Log("Pause ��ư");
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}

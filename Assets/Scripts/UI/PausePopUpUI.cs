using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PausePopUpUI : SceneUI		// 일시정지 UI는 Scene에 있는 거라서 SceneUI 상속받음
{
	PlayerController playerController;

	protected override void Awake()
	{
		base.Awake();

		buttons["PauseButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		Debug.Log("Pause 버튼");
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}

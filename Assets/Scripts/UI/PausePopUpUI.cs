using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PausePopUpUI : SceneUI		// 일시정지 UI는 Scene에 있는 거라서 SceneUI 상속받음
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PauseButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}

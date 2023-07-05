using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{

	protected override void Awake()
	{
		base.Awake();

		buttons["StopButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
		buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}

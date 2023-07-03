using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMenuUI : SceneUI
{
	protected override void Awake()
	{
		base.Awake();

		//buttons["InfoButton"].onClick.AddListener(() => { GameManager.UI.ShowWindowUI<WindowUI>("UI/WindowUI"); });
		//buttons["SoundButton"].onClick.AddListener(() => { Debug.Log("Sound"); });
		//buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
		//GameManager.UI.ShowPopUpUI("UI/PausePopUpUI");
	}
}

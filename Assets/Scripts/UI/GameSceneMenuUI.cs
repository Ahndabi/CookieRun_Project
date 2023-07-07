using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMenuUI : SceneUI
{
	protected override void Awake()
	{
		base.Awake();
	}

	public void OpenPausePopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}

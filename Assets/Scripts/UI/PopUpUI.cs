using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : BaseUI
{/*
	protected override void Awake()
	{
		base.Awake();

		//buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}*/

	public override void CloseUI()
	{
		base.CloseUI();

		GameManager.UI.ClosePopUpUI();
	}
}

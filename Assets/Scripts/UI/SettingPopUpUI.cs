using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		//buttons["SaveButton"].onClick.AddListener(() => { CloseUI(); });
		//buttons["CancelButton"].onClick.AddListener(() => { CloseUI(); });
		buttons["StopButton"].onClick.AddListener(() => { CloseUI(); });
	}
}

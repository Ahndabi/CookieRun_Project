using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["ExitButton"].onClick.AddListener(() => { OnClickExit(); });
		buttons["ContinueButton"].onClick.AddListener(() => { OnClickContinue(); });
	}

	void OnClickExit()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void OnClickContinue()
	{
        Time.timeScale = 1;
		Destroy(gameObject);
    }
}

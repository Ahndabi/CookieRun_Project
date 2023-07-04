using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarUI : MonoBehaviour
{
	Slider Hpbar;

	private void Awake()
	{
		Hpbar = GetComponent<Slider>();
	}

	private void Update()
	{
		DecreaseHPBar();
	}

	void DecreaseHPBar()
	{
		GameManager.UI.ChangedHP();
		Hpbar.value = GameManager.UI.curHP;
	}
}

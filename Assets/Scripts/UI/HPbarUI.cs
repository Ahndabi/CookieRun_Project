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

    private void OnEnable()
    {
		StartCoroutine(DecreaseHPBarRoutine());
    }

    IEnumerator DecreaseHPBarRoutine()
	{
		while (true)
		{
            GameManager.UI.ChangedHP();
            Hpbar.value = GameManager.UI.curHP;
			yield return null;
        }
    }
}

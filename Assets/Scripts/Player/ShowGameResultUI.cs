using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameResultUI : MonoBehaviour
{
    void Start()
    {
		StartCoroutine(ShowUIRoutine());
    }

	IEnumerator ShowUIRoutine()
	{
		yield return new WaitForSecondsRealtime(2f);
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameResultUI");
	}
}

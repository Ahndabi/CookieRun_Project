using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameResultUI : MonoBehaviour
{
    void OnEnable()
    {
		// StartCoroutine(ShowUIRoutine());
    }

	IEnumerator ShowUIRoutine()
	{
		yield return new WaitForSecondsRealtime(2f);
		// GameManager.UI.ShowPopUpUI<PopUpUI>("UI/GameResultUI");

        Canvas canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        GameObject resultUI = Resources.Load<GameObject>("UI/GameResultUI");
        Instantiate<GameObject>(resultUI, canvas.transform);
    }
}

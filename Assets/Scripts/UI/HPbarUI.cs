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

    private void Start()
    {
    }

    private void OnEnable()
    {
        Debug.Log("시작");
        Hpbar.value = GameManager.Data.maxHp;
        StartCoroutine(DecreaseHPBarRoutine());
    }

    IEnumerator DecreaseHPBarRoutine()
	{
		while (true)	// TODO : 코루틴 종료 조건 없음
		{
			GameManager.Data.ChangeHp();
			Hpbar.value = GameManager.Data.HP;
			yield return null;
        }
    }
}

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
        Hpbar.value = GameManager.Data.maxHp;
        StartCoroutine(DecreaseHPBarRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(DecreaseHPBarRoutine());
    }

    IEnumerator DecreaseHPBarRoutine()
	{
		while (true)
		{
			GameManager.Data.ChangeHp();
			Hpbar.value = GameManager.Data.HP;
			yield return null;
        }
    }
}

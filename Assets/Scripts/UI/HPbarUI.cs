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
        Debug.Log("����");
        Hpbar.value = GameManager.Data.maxHp;
        StartCoroutine(DecreaseHPBarRoutine());
    }

    IEnumerator DecreaseHPBarRoutine()
	{
		while (true)	// TODO : �ڷ�ƾ ���� ���� ����
		{
			GameManager.Data.ChangeHp();
			Hpbar.value = GameManager.Data.HP;
			yield return null;
        }
    }
}

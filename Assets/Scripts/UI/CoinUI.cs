using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
	// Jelly �浹ü�� ���� ������ AddCount �Լ� �ҷ�����
	TMP_Text CoinCountView;

	private void Awake()
	{
		CoinCountView = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		GameManager.Data.OnCointChanged += ChangeText;
	}

	private void OnDisable()
	{
		GameManager.Data.OnCointChanged -= ChangeText;
	}

	private void ChangeText(int count)
	{
		CoinCountView.text = count.ToString();
	}
}

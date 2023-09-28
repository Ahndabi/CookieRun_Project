using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JellyUI : MonoBehaviour
{
	// Jelly �浹ü�� ���� ������ AddCount �Լ� �ҷ�����

	public TMP_Text JellyCountView;

	private void Awake()
	{
		JellyCountView = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		GameManager.Data.OnJellyChanged += ChangeText;
	}

	private void OnDisable()
	{
		GameManager.Data.OnJellyChanged -= ChangeText;
	}

	private void ChangeText(int count)
	{
		JellyCountView.text = count.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JellyUI : MonoBehaviour
{
	// Jelly 충돌체랑 닿을 때마다 AddCount 함수 불러오기

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

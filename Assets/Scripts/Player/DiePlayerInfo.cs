using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayerInfo : MonoBehaviour
{
	// DiePlayer는 Player의 위치를 그대로 따라다녀야 함. LateUpdate를 쓰면 될듯

	public Transform Player;

	private void Awake()
	{
		Player = GameObject.FindWithTag("Player").transform;
	}

	private void LateUpdate()
	{
		gameObject.transform.position = Player.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSetting : MonoBehaviour
{
	// 처음 게임씬 넘어갈 때 플레이어는 삭제된 상태에서 생성되어야 함
	public GameObject Player;

	private void Awake()
	{
		Player = GameManager.Resource.Load<GameObject>("Prefabs/Player");
	}

	private void Start()
	{
		//Instantiate(Player, new Vector3(-5.47f, -2.41f, 0), Quaternion.identity);
	}
}

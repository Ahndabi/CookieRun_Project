using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSetting : MonoBehaviour
{
	// ó�� ���Ӿ� �Ѿ �� �÷��̾�� ������ ���¿��� �����Ǿ�� ��
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

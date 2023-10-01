using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayerInfo : MonoBehaviour
{
	// DiePlayer�� Player�� ��ġ�� �״�� ����ٳ�� ��. LateUpdate�� ���� �ɵ�

	public Transform Player;

	private void Awake()
	{
        // Player = GameObject.FindWithTag("Player").transform;
        // gameObject.SetActive(false);
    }

    private void Start()
    {
        // gameObject.SetActive(false);
    }

    private void OnEnable()
    {
		Player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
	{
		gameObject.transform.position = Player.transform.position;
	}
}

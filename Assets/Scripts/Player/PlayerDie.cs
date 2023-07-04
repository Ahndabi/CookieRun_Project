using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDie : MonoBehaviour
{
	// HP curHP���� 0�̸� Die
	// ������ �ִϸ��̼�
	// �÷��̾� �۵� ����
	// 2.5 ~ 3�� �ڿ� ���� ����
	public UnityEvent OnDie;
	public GameObject DiePlayer;
	public GameObject Player;
	PlayerInput inputSystem;
	Vector3 cameraPos;

	private void Awake()
	{
		inputSystem = GetComponent<PlayerInput>();
		Player = GameObject.FindWithTag("Player");
	}

	private void Start()
	{
		cameraPos = Camera.main.transform.position;     // ������ ���� ī�޶� ��ġ
	}

	private void Update()
	{
		if (GameManager.UI.curHP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		OnDie?.Invoke();

		// ���� Player�� ��Ȱ��ȭ, DiePlayer Ȱ��ȭ
		DiePlayer.SetActive(true);
		Player.SetActive(false);
		//gameObject.SetActive(false);

		// �ð� ����. �ִϸ��̼��� Animator���� Update Mode�� Unscaled Time���� �����ؼ� �ִϸ��̼Ǹ� ����ǰ� ��
		Time.timeScale = 0;
		
		// ī�޶� ����ġ
		Camera.main.transform.position = cameraPos;

		// inputsystem ��Ȱ��ȭ. ���� �ȵǰ�
		inputSystem.enabled = false;

		// 3�� �ڿ� ���� UI ������ ��
	}
}

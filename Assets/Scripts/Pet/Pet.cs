using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Pet : MonoBehaviour
{
	GameObject target;   // 플레이어
	[SerializeField] float speed = 1f;

	private void Start()
	{
		target = GameObject.FindWithTag("Player");		// 플레이어를 태그를 통해 target으로 넣어줌
	}

	private void FixedUpdate()
	{
		JumpToPlayer();
	}

	void JumpToPlayer()     // 플레이어를 따라 점프 (여기서는 애니메이션도 있음)
	{
		gameObject.transform.position = target.transform.position + new Vector3(-3.5f, 1.1f, 0);
		transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);	// 부드럽게 움직이기 위해 Lerp 사용
	}
}

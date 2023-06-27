using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item은 기본젤리, 곰돌이 젤리, 코인이 있다.
// 그래서 상속을 통해 구현할 것임

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;

	public abstract void Contact();     // 플레이어랑 닿았을 때 함수
										// 1. Destroy
										// 2. UI점수 올리기
	private void Start()
	{
		ScrollSpeed = 10.5f;
	}

	private void Update()
	{
		Move();
	}

	void Move()
	{
		gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
		Destroy(gameObject, 5f);
	}
}

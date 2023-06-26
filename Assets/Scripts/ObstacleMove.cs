using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;

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

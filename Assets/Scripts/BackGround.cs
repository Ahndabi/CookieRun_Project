using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField] float speed;
	MeshRenderer renderer;
	float x = 0;
	float y = 0;

	private void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		renderer.material.mainTextureOffset = new Vector2(x, y);
		x = x + Time.deltaTime * speed;
		/*
		x += (speed * Time.deltaTime);

		Vector2 offset = new Vector2(x, 0);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);*/  // << 이건 됩니당
	}
}

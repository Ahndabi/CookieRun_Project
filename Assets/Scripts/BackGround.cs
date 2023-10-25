using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField] public float speed;
	MeshRenderer renderer;
	float x = 0;
	float y = 0;

	private void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

    private void Update()
    {
        if (x > renderer.bounds.size.x)    // x값이 배경 오브젝트의 가로 너비보다 커졌다면 다시 0으로 초기화
        {
            x = 0;
        }

        renderer.material.mainTextureOffset = new Vector2(x, y);
        x = x + Time.deltaTime * speed;
    }

}

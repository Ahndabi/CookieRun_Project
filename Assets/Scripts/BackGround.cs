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
        if (x > renderer.bounds.size.x)    // x���� ��� ������Ʈ�� ���� �ʺ񺸴� Ŀ���ٸ� �ٽ� 0���� �ʱ�ȭ
        {
            x = 0;
        }

        renderer.material.mainTextureOffset = new Vector2(x, y);
        x = x + Time.deltaTime * speed;
    }

}

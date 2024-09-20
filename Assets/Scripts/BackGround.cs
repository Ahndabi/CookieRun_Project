using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField] public float speed;	// 배경 스크롤링 속도
	new MeshRenderer renderer;
	float x = 0;

	private void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		renderer.material.mainTextureOffset = new Vector2(x, 0);
		x = x + Time.deltaTime * speed;
	}
}

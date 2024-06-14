using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField] public float speed;	// 배경 스크롤링 속도
	new MeshRenderer renderer;
	float x = 0;
	float y = 0;

	private void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		//if (PlayerBase.isDie == false)
		//{
			renderer.material.mainTextureOffset = new Vector2(x, y);
			x = x + Time.deltaTime * speed;
		//}
	}
}

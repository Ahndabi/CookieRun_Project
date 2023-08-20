using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item은 기본젤리, 곰돌이 젤리, 코인이 있다.
// 그래서 상속을 통해 구현할 것임

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;
	protected AudioClip getSound;
	public bool isMagnetRangeTrigger = false;
	[SerializeField] GameObject pet;
	[SerializeField] Pet petScript;

	public abstract void Contact();     // 플레이어랑 닿았을 때 함수
										// 1. Destroy
										// 2. UI점수 올리기
	private void Start()
	{
		ScrollSpeed = 10.5f;
		pet = GameObject.FindGameObjectWithTag("Pet");  // 자석 후 펫의 위치를 받아옴
		petScript = pet.GetComponent<Pet>();
	}

	private void Update()
	{
		Move();

		if (petScript.isMagnet)     // TODO : &&isMagnetRangeTrigger  Magnet 충돌체 안에 trigger되면. 충돌 trigger 안에 bool 자료형 만들자
		{
			MagnetItemRole();
		}
	}

	void Move()
	{
		gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
		Destroy(gameObject, 5f);
	}

	public void MagnetItemRole()
	{
		// 이 함수가 호출되면 아이템은 Pet의 위치로 이동해야함
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
	}



	// 이거 왜 충돌체 감지 안 할까!
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "MagnetRange")
		{
			Debug.Log("충돌체 안에 들어옴");
			isMagnetRangeTrigger = true;
		}
	}
}

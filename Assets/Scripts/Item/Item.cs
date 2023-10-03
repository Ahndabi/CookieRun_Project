using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item은 기본젤리, 곰돌이 젤리, 코인
// 아이템들은 이 스크립트 상속

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;
	protected AudioClip getSound;
	public bool isMagnetRangeTrigger = false;
	[SerializeField] GameObject pet;

    protected Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();  // 아이템들을 점수와 함께 저장할 딕셔너리

	public abstract void ContactWithPlayer();     // 플레이어랑 닿았을 때 함수
                                        // 1. Destroy
                                        // 2. UI점수 올리기

    private void Start()
	{
		ScrollSpeed = 10.5f;
		pet = GameObject.FindGameObjectWithTag("Pet");  // 자석 후 펫의 위치를 받아옴
	}

    private void OnEnable()
    {
		StartCoroutine(MoveRoutine());
    }

    private void OnDisable()
    {
		StopCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
	{
        while (true)
        {
            gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
            Destroy(gameObject, 5f);
            yield return null;
        }
	}
    
    /*
	public void MagnetItemRole()
	{
		// 이 함수가 호출되면 아이템은 Pet의 위치로 이동해야함
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
	}*/

    // 이거 왜 충돌체 감지 안 할까!\
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("충돌체 안에 들어옴");
            isMagnetRangeTrigger = true;
        }
    }
}

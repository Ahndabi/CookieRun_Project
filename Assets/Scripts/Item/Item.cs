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
    float time;

    protected Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();  // 아이템들을 점수와 함께 저장할 딕셔너리

	public abstract void ContactWithPlayer();     // 플레이어랑 닿았을 때 함수
                                                  // 1. Destroy
                                                  // 2. UI점수 올리기
    public abstract void ContactWithPet();        // 펫이 자석기능 중일 때 펫이랑 닿았을 때의 함수 (위와 동일)

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
            time += Time.deltaTime;
            gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
            // Destroy(gameObject, 5f);
            if (time > 5f)
            {
                GameManager.Pool.Release<GameObject>(gameObject);
            }
            yield return null;
        }
	}
}

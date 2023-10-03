using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Pet : MonoBehaviour
{
	GameObject player;
	[SerializeField] float speed = 0.5f;
	public Transform Originalpos;
	public bool isMagnet = false;
	// [SerializeField] Collider2D magnetRange;
	[SerializeField] GameObject magnetRange;
	
	private void Start()
	{
		player = GameObject.FindWithTag("Player");      // 플레이어를 태그를 통해 target으로 넣어줌
		Originalpos = gameObject.transform;
		// magnetRange = gameObject.GetComponentInChildren<Collider2D>();      // 자식에 있는 콜라이더가 magnetRange. 평소엔 비활성화
		// magnetRange.enabled = false;
		magnetRange.SetActive(false);
	}

	private void LateUpdate()
	{
		JumpToPlayer();
	}

	void JumpToPlayer()     // 플레이어를 따라 점프 (여기서는 애니메이션도 있음)
	{
		if (!isMagnet)		// isMagnet이 false일 때, 즉 자석기능 없는 상황일 때는 항상 플레이어 왼쪽에서 졸졸쫒아다니기
		{
			gameObject.transform.position = player.transform.position + new Vector3(-3.5f, 1.1f, 0);
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), speed);    // 부드럽게 움직이기 위해 Lerp 사용
		}
	}

	public void Magnet()
	{
		StartCoroutine(MagnetRoutine());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator MagnetRoutine()		// 자석먹은 펫 기능 여기에 구현(3초 동안 실행)
	{
        // 자석 아이템을 먹으면 아이템을 끌어당김
        // 펫이 플레이어 오른쪽으로 이동한 다음에 (+애니메이션)
        // 콜라이더로 trigger 되어 있는 아이템들을 자신의 position으로 이동시킴
        // 그리고 펫에 아이템이 닿으면 Destroy되는데 점수도 반영됨
        /*
		isMagnet = true;	// Update 함수 막아두기 위해 bool 변수 사용
		gameObject.transform.position = new Vector3(-1.5f, -1.5f, 0); // 플레이어 앞으로 이동
		magnetRange.enabled = true;     // 충돌체 감지 true

		yield return new WaitForSeconds(3f);
		isMagnet = false;
		gameObject.transform.position = Originalpos.position;   // 원래 자리로 되돌아가기
		magnetRange.enabled = false;
		*/

        isMagnet = true;    // Update 함수 막아두기 위해 bool 변수 사용
		magnetRange.SetActive(true);
        gameObject.transform.position = new Vector3(-1.5f, -1.5f, 0); // 플레이어 앞으로 이동

        yield return new WaitForSeconds(3f);
        isMagnet = false;
        magnetRange.SetActive(false);
        gameObject.transform.position = Originalpos.position;   // 원래 자리로 되돌아가기
    }


}

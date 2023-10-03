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
		player = GameObject.FindWithTag("Player");      // �÷��̾ �±׸� ���� target���� �־���
		Originalpos = gameObject.transform;
		// magnetRange = gameObject.GetComponentInChildren<Collider2D>();      // �ڽĿ� �ִ� �ݶ��̴��� magnetRange. ��ҿ� ��Ȱ��ȭ
		// magnetRange.enabled = false;
		magnetRange.SetActive(false);
	}

	private void LateUpdate()
	{
		JumpToPlayer();
	}

	void JumpToPlayer()     // �÷��̾ ���� ���� (���⼭�� �ִϸ��̼ǵ� ����)
	{
		if (!isMagnet)		// isMagnet�� false�� ��, �� �ڼ���� ���� ��Ȳ�� ���� �׻� �÷��̾� ���ʿ��� �����i�ƴٴϱ�
		{
			gameObject.transform.position = player.transform.position + new Vector3(-3.5f, 1.1f, 0);
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), speed);    // �ε巴�� �����̱� ���� Lerp ���
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

	IEnumerator MagnetRoutine()		// �ڼ����� �� ��� ���⿡ ����(3�� ���� ����)
	{
        // �ڼ� �������� ������ �������� ������
        // ���� �÷��̾� ���������� �̵��� ������ (+�ִϸ��̼�)
        // �ݶ��̴��� trigger �Ǿ� �ִ� �����۵��� �ڽ��� position���� �̵���Ŵ
        // �׸��� �꿡 �������� ������ Destroy�Ǵµ� ������ �ݿ���
        /*
		isMagnet = true;	// Update �Լ� ���Ƶα� ���� bool ���� ���
		gameObject.transform.position = new Vector3(-1.5f, -1.5f, 0); // �÷��̾� ������ �̵�
		magnetRange.enabled = true;     // �浹ü ���� true

		yield return new WaitForSeconds(3f);
		isMagnet = false;
		gameObject.transform.position = Originalpos.position;   // ���� �ڸ��� �ǵ��ư���
		magnetRange.enabled = false;
		*/

        isMagnet = true;    // Update �Լ� ���Ƶα� ���� bool ���� ���
		magnetRange.SetActive(true);
        gameObject.transform.position = new Vector3(-1.5f, -1.5f, 0); // �÷��̾� ������ �̵�

        yield return new WaitForSeconds(3f);
        isMagnet = false;
        magnetRange.SetActive(false);
        gameObject.transform.position = Originalpos.position;   // ���� �ڸ��� �ǵ��ư���
    }


}

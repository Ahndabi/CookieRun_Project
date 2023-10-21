using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item�� �⺻����, ������ ����, ����
// �����۵��� �� ��ũ��Ʈ ���

public abstract class Item : MonoBehaviour
{
	[SerializeField] float ScrollSpeed;
	protected AudioClip getSound;
	public bool isMagnetRangeTrigger = false;
	[SerializeField] GameObject pet;
    float time;

    protected Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();  // �����۵��� ������ �Բ� ������ ��ųʸ�

	public abstract void ContactWithPlayer();     // �÷��̾�� ����� �� �Լ�
                                                  // 1. Destroy
                                                  // 2. UI���� �ø���
    public abstract void ContactWithPet();        // ���� �ڼ���� ���� �� ���̶� ����� ���� �Լ� (���� ����)

    private void Start()
	{
		ScrollSpeed = 10.5f;
		pet = GameObject.FindGameObjectWithTag("Pet");  // �ڼ� �� ���� ��ġ�� �޾ƿ�
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

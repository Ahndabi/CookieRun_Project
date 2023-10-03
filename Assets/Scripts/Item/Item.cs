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

    protected Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();  // �����۵��� ������ �Բ� ������ ��ųʸ�

	public abstract void ContactWithPlayer();     // �÷��̾�� ����� �� �Լ�
                                        // 1. Destroy
                                        // 2. UI���� �ø���

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
            gameObject.transform.Translate(Vector2.left * ScrollSpeed * Time.deltaTime);
            Destroy(gameObject, 5f);
            yield return null;
        }
	}
    
    /*
	public void MagnetItemRole()
	{
		// �� �Լ��� ȣ��Ǹ� �������� Pet�� ��ġ�� �̵��ؾ���
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
	}*/

    // �̰� �� �浹ü ���� �� �ұ�!\
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("�浹ü �ȿ� ����");
            isMagnetRangeTrigger = true;
        }
    }
}

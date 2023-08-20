using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetControl : MonoBehaviour
{
	public List<GameObject> items;
	Collider2D magnetRange;
	GameObject pet;

	public bool isTrigger = false;		// �̰� Item ���ٰ� �־߸�����
	
	[SerializeField] Item itemScript;
	[SerializeField] GameObject Item;

	void Awake()
    {
		items = new List<GameObject>();
		pet = GameObject.FindGameObjectWithTag("Pet");
	}

	private void OnTriggerEnter2D(Collider2D col)     // �ڽ� �ݶ��̴��� ������. �ٵ� �̰� ���� ��ũ��Ʈ�� ���� �ڽĿ� �־���� �ϳ�?
	{
		// ������ �����ܼ� ���̶� �������̶� ������ �������� destroy.
		if (col.tag == "Item")
		{
			//isTrigger = true;
			items.Add(col.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Item")
		{
			//isTrigger = false;
		}
	}
}


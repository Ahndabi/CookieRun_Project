using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetControl : MonoBehaviour
{
	public List<GameObject> items;
	Collider2D magnetRange;
	GameObject pet;

	public bool isTrigger = false;		// 이걸 Item 에다가 둬야맞을듯
	
	[SerializeField] Item itemScript;
	[SerializeField] GameObject Item;

	void Awake()
    {
		items = new List<GameObject>();
		pet = GameObject.FindGameObjectWithTag("Pet");
	}

	private void OnTriggerEnter2D(Collider2D col)     // 자식 콜라이더에 들어오면. 근데 이거 따로 스크립트를 만들어서 자식에 넣어줘야 하낭?
	{
		// 아이템 끌어당겨서 펫이랑 아이템이랑 닿으면 아이템은 destroy.
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


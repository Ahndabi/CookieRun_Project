using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	// Resources/Prefasb�� �ִ� Player ��������
	public GameObject Player;
	public Animator anim;
	public BoxCollider2D col;
	//public AnimatorController anim;

	private void Awake()
	{
		//Player = GameManager.Resource.Load<GameObject>("Prefabs/Player");
		//anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		//col = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
	}

}

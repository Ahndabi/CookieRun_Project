using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		// ���� ������ ������(+�ִϸ��̼�) �տ� �ִ� �����۵� �ڼ�ó�� ������
		// LayerMask�� �ݶ��̴� ������ �տ� ���� ������ üũ�ϰ� 
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Contact();
			SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
		}
	}
}

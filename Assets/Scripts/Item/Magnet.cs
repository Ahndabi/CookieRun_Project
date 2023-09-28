using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
	Pet pet;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
        items.Add(gameObject, 0);  // items ��ųʸ��� �߰�
    }

    public override void Contact()
	{
		// ���� ������ ������(+�ִϸ��̼�) �տ� �ִ� �����۵� �ڼ�ó�� ������
		// �꿡 �ִ� �ڼ��Լ��� ���⼭ ȣ���Ұ��� 
		gameObject.SetActive(false);
		pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>();
		pet.Magnet();   // < �� �Լ� �ȿ� ��� ��� ����
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

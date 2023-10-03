using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
	Pet pet;

	private void Awake()
	{
		getSound = GameManager.Resource.Load<AudioClip>("Sound/SoundEff_GetCoinJelly");
        pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>();
        items.Add(gameObject, 0);  // items ��ųʸ��� �߰�
    }

    public override void ContactWithPlayer()
	{
		// ���� ������ ������(+�ִϸ��̼�) �տ� �ִ� �����۵� �ڼ�ó�� ������
		// �꿡 �ִ� �ڼ��Լ��� ���⼭ ȣ���Ұ��� 
		gameObject.SetActive(false);
		pet.Magnet();   // < �� �Լ� �ȿ� ��� ��� ����
	}

    public override void ContactWithPet()
    {
        gameObject.SetActive(false);
        GameManager.Data.AddJellyCount(items[gameObject]);  // ������ ���� ������ ���� 22�� ����
    }

    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			ContactWithPlayer();
			SoundManager.instance.SFXPlay("SoundEff_GetCoinJelly", getSound);
		}
	}

    public void MagnetItemRole()
    {
        // �� �Լ��� ȣ��Ǹ� �������� Pet�� ��ġ�� �̵��ؾ���
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pet.transform.position, 1f);
    }
}

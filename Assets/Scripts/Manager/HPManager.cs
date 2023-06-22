using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPManager : MonoBehaviour
{
	// HP ����
	float maxHP = 100;
	public float curHP;

	private void Start()
	{
		curHP = maxHP;		// ó������ Hp�� max���� �Ѵ�.
	}

	// �������� ������ hp�� �����Ѵ�. 
	public void TakeDamageHP(float damage)
	{
		curHP -= damage;
	}

	// HP�� 0�� �� ������ �ð��� �����鼭 ��� HP�� �����Ѵ�.
	public void ChangedHP()
	{
		curHP -= Time.deltaTime * 3;
	}
}

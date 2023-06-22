using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPManager : MonoBehaviour
{
	// HP 관리
	float maxHP = 100;
	public float curHP;

	private void Start()
	{
		curHP = maxHP;		// 처음에는 Hp가 max여야 한다.
	}

	// 데미지를 받으면 hp가 감소한다. 
	public void TakeDamageHP(float damage)
	{
		curHP -= damage;
	}

	// HP가 0이 될 때까지 시간이 지나면서 계속 HP가 감소한다.
	public void ChangedHP()
	{
		curHP -= Time.deltaTime * 3;
	}
}

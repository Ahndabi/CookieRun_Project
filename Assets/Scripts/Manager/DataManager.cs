using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 1. 아이템 점수
	// 2. HP

	public int JellyCount;
	public int CoinCount;

	private float hp;
	public float HP { get { return hp; } }
	public float maxHp = 100;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;
	public UnityAction<int> OnTakeDamage;   // 데미지 받을 때 = HP 닳을 때

    private void Start()
    {
		hp = maxHp;
    }

    public void AddJellyCount(int count)
	{
		JellyCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnJellyChanged?.Invoke(JellyCount);
	}

	public void AddCoinCount(int count)
	{
		CoinCount += count;        // 데이터변조 때문에 =대입이 아니라 더해주는 방식으로!!
		OnCointChanged?.Invoke(CoinCount);
	}

	public void DecreaseHp(float damage)	// 데미지 받고 Hp 감소
	{
		hp -= damage;
	}

	public void IncreaseHp(float heartLifeHp)	// 회복시켜주는 아이템 먹고 Hp 증가
	{
		hp += heartLifeHp;
	}

	public void ChangeHp()
	{
		hp -= Time.deltaTime * 5;
	}

}

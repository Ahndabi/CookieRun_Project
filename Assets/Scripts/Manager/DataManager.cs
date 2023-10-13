using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
	// 1. ������ ����
	// 2. HP

	public int JellyCount;
	public int CoinCount;

	private float hp;
	public float HP { get { return hp; } }
	public float maxHp = 100;

	public UnityAction<int> OnJellyChanged;
	public UnityAction<int> OnCointChanged;
	public UnityAction<int> OnTakeDamage;   // ������ ���� �� = HP ���� ��

    private void OnEnable()
    {
		hp = maxHp;
    }

    public void AddJellyCount(int count)
	{
		JellyCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		OnJellyChanged?.Invoke(JellyCount);
	}

	public void AddCoinCount(int count)
	{
		CoinCount += count;        // �����ͺ��� ������ =������ �ƴ϶� �����ִ� �������!!
		OnCointChanged?.Invoke(CoinCount);
	}

	public void DecreaseHp(float damage)	// ������ �ް� Hp ����
	{
		hp -= damage;
	}

	public void IncreaseHp(float heartLifeHp)	// ȸ�������ִ� ������ �԰� Hp ����
	{
		hp += heartLifeHp;
	}

	public void ChangeHp()
	{
		// TODO : ���߿� 5�� �������ֱ�. ������ �����
		hp -= Time.deltaTime * 5;
	}

	public void ZombieSpawnHp()
	{
		hp = 30f;
	}
}

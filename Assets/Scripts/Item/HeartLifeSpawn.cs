using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLifeSpawn : MonoBehaviour
{
	// 7�ʸ��� y(3.8)�� ������ ��� �����ϱ�

	[SerializeField] GameObject HeartLifePrefab;
	float time = 7;

	private void OnEnable()
	{
		StartCoroutine(HeartLifeRoutine());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator HeartLifeRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(time);
			Instantiate(HeartLifePrefab, new Vector3(18f, 3.8f, 0f), Quaternion.identity);
		}
	}
}

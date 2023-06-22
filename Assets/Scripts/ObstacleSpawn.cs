using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
	// SpawnPoint�� �� �� ���ε�, �ڷ�ƾ�� ����ؼ�
	// Point1���� Set1�� ��ȯ�ϰų� Point2���� Set2�� ��ȯ�ϰų��� �������� ��� ����

	[SerializeField] Transform[] spawnPoint;  // ��ֹ� �� ������ ��Ȱ ����
	[SerializeField] float spawnTime;		  // ��Ȱ ��Ÿ��
	[SerializeField] GameObject[] SetPrefab;  // ��ֹ� �� ������ ��Ʈ ������


	private void OnEnable()
	{
		StartCoroutine(SpawnRoutine());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator SpawnRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnTime);

			int a = Random.Range(0, spawnPoint.Length);

			Instantiate(SetPrefab[a], spawnPoint[a].position, Quaternion.identity);
		}
	}
}

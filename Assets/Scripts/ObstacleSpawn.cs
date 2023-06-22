using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
	// SpawnPoint가 총 두 개인데, 코루틴을 사용해서
	// Point1에서 Set1을 소환하거나 Point2에서 Set2를 소환하거나를 랜덤으로 계속 생성

	[SerializeField] Transform[] spawnPoint;  // 장애물 및 아이템 부활 지점
	[SerializeField] float spawnTime;		  // 부활 쿨타임
	[SerializeField] GameObject[] SetPrefab;  // 장애물 및 아이템 세트 프리팹


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

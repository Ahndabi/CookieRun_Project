using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObstacleCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;    // 이동속도
	GameObject JumpOb;  // 장애물 프리팹
	GameObject SlideOb; // 장애물 프리팹
	protected string[] values;
	protected float x;
	protected float y;
	protected float spawnTime;
	protected string[] lines;

	private void Awake()
	{
		JumpOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/JumpObstacle1");
		SlideOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/SlideObstacle1");
	}

	void Start()
	{
		CSVReader();
	}

	public void CSVReader()
	{
		TextAsset csvFile = Resources.Load("ObstacleCSV") as TextAsset;
		string csvText = csvFile.text;
		//Debug.Log(csvText);

		if (csvFile != null)
		{
			lines = csvText.Split('\n');
			StartCoroutine(ObstacleRoutine());
		}
		else
		{
			Debug.LogError("CSV 파일이 존재하지 않습니다: " + csvText);
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator ObstacleRoutine()
	{
		foreach (string line in lines)
		{
			values = line.Split(',');   // 줄을 구분자로 분리하여 값 얻기
										// values[] = [0] : JumpOb
										//			  [1] : 13
										//		      [2] : -3.239
										//			  [3] : 2
			x = float.Parse(values[1]);
			y = float.Parse(values[2]);
			spawnTime = float.Parse(values[3]);

			if (values[0] == "JumpOb")
			{
				Instantiate(JumpOb, new Vector3(x, y, 0), Quaternion.identity);     // 점프 장애물 생성
			}

			else if (values[0] == "SlideOb")
			{
				Instantiate(SlideOb, new Vector3(x, y, 0), Quaternion.identity);     // 점프 장애물 생성
			}

			yield return new WaitForSeconds(spawnTime);
		}
	}
}

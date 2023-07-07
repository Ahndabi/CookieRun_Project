using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ALLCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // 이동속도
	GameObject Blue;        // 아이템 프리팹
	GameObject Bear;        // 아이템 프리팹
	GameObject Sliver;      // 아이템 프리팹
	GameObject Gold;        // 아이템 프리팹
	GameObject Bigger;      // 아이템 프리팹
	GameObject HeartLife;   // 아이템 프리팹
	GameObject JumpOb;  // 장애물 프리팹
	GameObject SlideOb; // 장애물 프리팹

	protected string[] values;
	protected string[] names;
	protected float x;
	protected float y;
	protected float spawnTime = 0.2f;
	protected string[] lines;

	private void Awake()
	{
		Blue = Resources.Load<GameObject>("Prefabs/BlueJelly");
		Bear = Resources.Load<GameObject>("Prefabs/BearJelly");
		Sliver = Resources.Load<GameObject>("Prefabs/SliverCoin");
		Gold = Resources.Load<GameObject>("Prefabs/GoldCoint");
		Bigger = Resources.Load<GameObject>("Prefabs/BiggerItem");
		HeartLife = Resources.Load<GameObject>("Prefabs/HeartLife");
		JumpOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/JumpObstacle1");
		SlideOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/SlideObstacle1");
	}

	void Start()
	{
		CSVReader();
		
		// 위에서 읽은 CSV 파일의 첫번째 행만 읽고 열의 개수만큼 list들을 만들어야 함
	}

	public void CSVReader()
	{
		TextAsset csvFile = Resources.Load("ALLCSV") as TextAsset;
		string csvText = csvFile.text;
		//Debug.Log(csvText);

		if (csvFile != null)
		{
			lines = csvText.Split('\n');        // lines[0] = "프리팹, 프리팹, 프리팹"
			StartCoroutine(CSVRoutine());		// lines[1] = "0, -3, -3, ,,,,,,,"
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


	IEnumerator CSVRoutine()
	{
		// lines[0]에는 아이템과 장애물이 무엇인지의 정보가 있고,
		// lines[1]부터 Instantiate 해주면 됨 그다음은 [2], [3] 이렇게,,,
		// 프리팹 이름들이 있는 lines[0] 부분만 일단 가져오기
		names = lines[0].Split(',');	// names 들에 프리팹 이름들이 순서대로 저장됨.

		for (int i = 1; i < lines.Length; ++i)
		{
			values = lines[i].Split(',');       // lines[1] 부터 ,을 기준으로 나누어서 values[]에 값 넣기 (y값 넣은 거임)
												// values[0] = -3.239	
												// values[1] = 0
												// values[2] = 0	,,,쭉쭉  -1  0	0	0	0
			
			// 만약에 값이 0이면 생성 안 하고 그냥 return


			// 여기서 프리팹 이름이랑 values 값이랑 연결시켜주고
			if (names.ToString() == "JumpOb")
			{
				// 만약 values[] 값이 0이면 yield return new WaitFor세컨드(1f) 똑같이. 그래야 시간 똑같이 흐르면서 안나올테니까
				Instantiate(JumpOb, new Vector3(13, float.Parse(values[0]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "SlideOb")
			{
				Instantiate(SlideOb, new Vector3(13, float.Parse(values[1]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "Blue")
			{
				Instantiate(Blue, new Vector3(13, float.Parse(values[2]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "Bear")
			{
				Instantiate(Bear, new Vector3(13, float.Parse(values[3]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "Sliver")
			{
				Instantiate(Sliver, new Vector3(13, float.Parse(values[4]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "Gold")
			{
				Instantiate(Gold, new Vector3(13, float.Parse(values[5]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "Bigger")
			{
				Instantiate(Bigger, new Vector3(13, float.Parse(values[6]), 0), Quaternion.identity);
			}
			
			if (names.ToString() == "HeartLife")
			{
				Instantiate(HeartLife, new Vector3(13, float.Parse(values[7]), 0), Quaternion.identity);
			}

			yield return new WaitForSeconds(1f);
		}
		

	}


	/*
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
	}*/


	/*
	IEnumerator ObstacleRoutine()
	{
		foreach (string line in lines)
		{
			values = line.Split(',');   // 줄을 구분자로 분리하여 값 얻기

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
	}*/
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ALLCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // 이동속도
	[SerializeField] GameObject Blue;				// 아이템 프리팹
	[SerializeField] GameObject Bear;				// 아이템 프리팹
	[SerializeField] GameObject Sliver;				// 아이템 프리팹
	[SerializeField] GameObject Gold;				// 아이템 프리팹
	[SerializeField] GameObject Bigger;				// 아이템 프리팹
	[SerializeField] GameObject HeartLife;			// 아이템 프리팹
	[SerializeField] GameObject JumpOb;				// 장애물 프리팹
	[SerializeField] GameObject SlideOb;			// 장애물 프리팹

	protected string[] values;
	protected string[] names;
	protected string[] lines;
	protected float spawnTime = 0.2f;

	private void Awake()
	{
		Blue = Resources.Load<GameObject>("Prefabs/Item/BlueJelly");
		Bear = Resources.Load<GameObject>("Prefabs/Item/BearJelly");
		Sliver = Resources.Load<GameObject>("Prefabs/Item/SilverCoin");
		Gold = Resources.Load<GameObject>("Prefabs/Item/GoldCoin");
		Bigger = Resources.Load<GameObject>("Prefabs/Item/Item_BiggerItem");
		HeartLife = Resources.Load<GameObject>("Prefabs/Item/HeartLife");
		JumpOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/JumpObstacle1");
		SlideOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/SlideObstacle1");
	}

	void Start()
	{
		CSVReader();
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
			values = lines[i].Split(','); 
			
			for (int j = 0; j < values.Length; ++j)
			{
				if (j == 0 && float.Parse(values[0]) != 0)		// values의 값이 0이 아니라면 생성!
				{
					Instantiate(JumpOb, new Vector3(13, float.Parse(values[0]), 0), Quaternion.identity);
				}
				if (j == 1 && float.Parse(values[1]) != 0)	
				{
					Instantiate(SlideOb, new Vector3(13, float.Parse(values[1]), 0), Quaternion.identity);
				}
				if (j == 2 && float.Parse(values[2]) != 0)	
				{
					Instantiate(Blue, new Vector3(13, float.Parse(values[2]), 0), Quaternion.identity);
				}
				if (j == 3 && float.Parse(values[3]) != 0)
				{
					Instantiate(Bear, new Vector3(13, float.Parse(values[3]), 0), Quaternion.identity);
				}
				if (j == 4 && float.Parse(values[4]) != 0)
				{
					Instantiate(Sliver, new Vector3(13, float.Parse(values[4]), 0), Quaternion.identity);
				}
				if (j == 5 && float.Parse(values[5]) != 0)		
				{
					Instantiate(Gold, new Vector3(13, float.Parse(values[5]), 0), Quaternion.identity);
				}
				if (j == 6 && float.Parse(values[6]) != 0)	
				{
					Instantiate(Bigger, new Vector3(13, float.Parse(values[6]), 0), Quaternion.identity);
				}
				if (j == 7 && float.Parse(values[7]) != 0)
				{
					Instantiate(HeartLife, new Vector3(13, float.Parse(values[7]), 0), Quaternion.identity);
				}
			}

			yield return new WaitForSeconds(0.2f);
		}
	}
}

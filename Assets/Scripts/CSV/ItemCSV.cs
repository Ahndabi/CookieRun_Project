using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // 이동속도
	GameObject Blue;   // 아이템 프리팹
	GameObject Bear;   // 아이템 프리팹
	GameObject Sliver;  // 아이템 프리팹
	GameObject Gold;	// 아이템 프리팹
	protected string[] values;
	protected float x;
	protected float y;
	protected float spawnTime = 0.1f;
	protected string[] lines;

	private void Awake()
	{
		Blue = Resources.Load<GameObject>("Prefabs/BlueJelly");
		Bear = Resources.Load<GameObject>("Prefabs/BearJelly");
		Sliver = Resources.Load<GameObject>("Prefabs/SliverCoin");
		Gold = Resources.Load<GameObject>("Prefabs/GoldCoint");
	}

	void Start()
	{
		CSVReader();
	}

	public void CSVReader()
	{
		TextAsset csvFile = Resources.Load("ItemCSV") as TextAsset;
		string csvText = csvFile.text;
		Debug.Log(csvText);

		if (csvFile != null)
		{
			lines = csvText.Split('\n');	// lines[0] = "Blue, -3, -3, -3, ,,,"
											// lines[1] = "Bear, -3, -3, ,,,,,,,"
			StartCoroutine(ItemRoutine());
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

	IEnumerator ItemRoutine()
	{
		foreach (string line in lines)
		{
			values = line.Split(',');       // ,로 구분하여 하나의 값 얻기
			// 첫번째 반복에서는 values[8]로, [0]="Blue", [1]="-3" .....

			for (int i = 1; i < values.Length; ++i)      // values[] 한 줄 실행	item, 2, 3
			{
				y = float.Parse(values[i]);			// 두 번째부터 y값으로 읽기	
				if (values[0] == "Blue")			// values [0]은 아이템 종류
				{
					if (float.Parse(values[i]) == 0)
					{
						yield return new WaitForSeconds(spawnTime);

						continue;
					}

					Instantiate(Blue, new Vector3(20, y, 0), Quaternion.identity);

				}

				if (values[0] == "Bear")
				{
					if (float.Parse(values[i]) == 0)
					{
						yield return new WaitForSeconds(spawnTime);

						continue;
					}
					y = float.Parse(values[i]);     // 두 번째부터 y값으로 읽기
					Instantiate(Bear, new Vector3(20, y, 0), Quaternion.identity);

				}
				yield return new WaitForSeconds(spawnTime);
			}
		}
	}
}

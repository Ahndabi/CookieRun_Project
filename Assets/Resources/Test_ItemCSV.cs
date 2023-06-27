using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ItemCSV : MonoBehaviour
{

	[SerializeField] float ScrollSpeed = 10.5f;     // �̵��ӵ�
	GameObject Blue;		// ������ ������
	GameObject Bear;		// ������ ������
	GameObject Sliver;		// ������ ������
	GameObject Gold;		// ������ ������
	[SerializeField] GameObject[] ItemPrefabs;  // ��ֹ� �� ������ ��Ʈ ������
	
	protected string[] values;
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
			lines = csvText.Split('\n');    // lines[0] = "Blue, -3, -3, -3, ,,,"
											// lines[1] = "Bear, -3, -3, ,,,,,,,"
			StartCoroutine(ItemRoutine());
		}
		else
		{
			Debug.LogError("CSV ������ �������� �ʽ��ϴ�: " + csvText);
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
			values = line.Split(',');       // ,�� �����Ͽ� �ϳ��� �� ���
											// ù��° �ݺ������� values[8]��, [0]="Blue", [1]="-3" .....

			for (int i = 0; i < values.Length - 1; ++i)      // values[] �� �� ����	item, 2, 3
			{
				int a = Random.Range(0, ItemPrefabs.Length);	// �������� �������� ������

				y = float.Parse(values[i]);         // �� ��°���� y������ �б�	
				/*
				if (float.Parse(values[i]) == 0)
				{
					yield return new WaitForSeconds(spawnTime);

					continue;
				}*/

				Instantiate(ItemPrefabs[a], new Vector3(20, y, 0), Quaternion.identity);

				yield return new WaitForSeconds(spawnTime);
			}
		}
	}
}
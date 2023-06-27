using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCSV : MonoBehaviour
{

	[SerializeField] float ScrollSpeed = 10.5f;     // �̵��ӵ�
	GameObject Blue;   // ������ ������
	GameObject Bear;   // ������ ������
	GameObject Sliver;  // ������ ������
	GameObject Gold;	// ������ ������
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
			Debug.LogError("CSV ������ �������� �ʽ��ϴ�: " + csvText);
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator ItemRoutine()
	{/*
		while (true)
		{
			foreach (string line in lines)
			{
				values = line.Split(',');   // ���� �����ڷ� �и��Ͽ� �� ���

				x = float.Parse(values[1]);
				y = float.Parse(values[2]);
				spawnTime = float.Parse(values[3]);

				if (values[0] == "Blue")
				{
					Instantiate(Blue, new Vector3(x, y, 0), Quaternion.identity);     // Blue ������ ����
					Destroy(gameObject, 5f);
				}

				else if (values[0] == "Bear")
				{
					Instantiate(Bear, new Vector3(x, y, 0), Quaternion.identity);     // Bear ������ ����
					Destroy(gameObject, 5f);
				}

				yield return new WaitForSeconds(spawnTime);
			}
		}*/

		foreach (string line in lines)
		{
			values = line.Split(',');       // ,�� �����Ͽ� �ϳ��� �� ���
			// ù��° �ݺ������� values[8]��, [0]="Blue", [1]="-3" .....

			for (int i = 1; i < values.Length; ++i)      // values[] �� �� ����	item, 2, 3
			{
				y = float.Parse(values[i]);			// �� ��°���� y������ �б�	
				if (values[0] == "Blue")			// values [0]�� ������ ����
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
					y = float.Parse(values[i]);     // �� ��°���� y������ �б�
					Instantiate(Bear, new Vector3(20, y, 0), Quaternion.identity);

				}
				yield return new WaitForSeconds(spawnTime);

			}

		}
		
		// value[0] �� (������ �������) ��� �ڷ�ƾ�� �� �ٸ��� �ؼ� ���ÿ� �����ϸ� ���ܾ�
	}
}

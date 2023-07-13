using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ALLCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // �̵��ӵ�
	[SerializeField] GameObject Blue;				// ������ ������
	[SerializeField] GameObject Bear;				// ������ ������
	[SerializeField] GameObject Sliver;				// ������ ������
	[SerializeField] GameObject Gold;				// ������ ������
	[SerializeField] GameObject Bigger;				// ������ ������
	[SerializeField] GameObject HeartLife;			// ������ ������
	[SerializeField] GameObject JumpOb;				// ��ֹ� ������
	[SerializeField] GameObject SlideOb;			// ��ֹ� ������

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
			lines = csvText.Split('\n');        // lines[0] = "������, ������, ������"
			StartCoroutine(CSVRoutine());		// lines[1] = "0, -3, -3, ,,,,,,,"
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

	IEnumerator CSVRoutine()
	{
		// lines[0]���� �����۰� ��ֹ��� ���������� ������ �ְ�,
		// lines[1]���� Instantiate ���ָ� �� �״����� [2], [3] �̷���,,,
		// ������ �̸����� �ִ� lines[0] �κи� �ϴ� ��������
		names = lines[0].Split(',');	// names �鿡 ������ �̸����� ������� �����.

		for (int i = 1; i < lines.Length; ++i)
		{
			values = lines[i].Split(','); 
			
			for (int j = 0; j < values.Length; ++j)
			{
				if (j == 0 && float.Parse(values[0]) != 0)		// values�� ���� 0�� �ƴ϶�� ����!
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ALLCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // �̵��ӵ�
	GameObject Blue;        // ������ ������
	GameObject Bear;        // ������ ������
	GameObject Sliver;      // ������ ������
	GameObject Gold;        // ������ ������
	GameObject Bigger;      // ������ ������
	GameObject HeartLife;   // ������ ������
	GameObject JumpOb;  // ��ֹ� ������
	GameObject SlideOb; // ��ֹ� ������

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
		
		// ������ ���� CSV ������ ù��° �ุ �а� ���� ������ŭ list���� ������ ��
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
			values = lines[i].Split(',');       // lines[1] ���� ,�� �������� ����� values[]�� �� �ֱ� (y�� ���� ����)
												// values[0] = -3.239	
												// values[1] = 0
												// values[2] = 0	,,,����  -1  0	0	0	0
			
			// ���࿡ ���� 0�̸� ���� �� �ϰ� �׳� return


			// ���⼭ ������ �̸��̶� values ���̶� ��������ְ�
			if (names.ToString() == "JumpOb")
			{
				// ���� values[] ���� 0�̸� yield return new WaitFor������(1f) �Ȱ���. �׷��� �ð� �Ȱ��� �帣�鼭 �ȳ����״ϱ�
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
			values = line.Split(',');   // ���� �����ڷ� �и��Ͽ� �� ���
										// values[] = [0] : JumpOb
									   	//			  [1] : 13
									   	//		      [2] : -3.239
									   	//			  [3] : 2
			x = float.Parse(values[1]);
			y = float.Parse(values[2]);
			spawnTime = float.Parse(values[3]);

			if (values[0] == "JumpOb")
			{
				Instantiate(JumpOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
			}

			else if (values[0] == "SlideOb")
			{
				Instantiate(SlideOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
			}

			yield return new WaitForSeconds(spawnTime);
		}
	}*/


	/*
	IEnumerator ObstacleRoutine()
	{
		foreach (string line in lines)
		{
			values = line.Split(',');   // ���� �����ڷ� �и��Ͽ� �� ���

			x = float.Parse(values[1]);
			y = float.Parse(values[2]);
			spawnTime = float.Parse(values[3]);

			if (values[0] == "JumpOb")
			{
				Instantiate(JumpOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
			}

			else if (values[0] == "SlideOb")
			{
				Instantiate(SlideOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
			}

			yield return new WaitForSeconds(spawnTime);
		}
	}*/
}

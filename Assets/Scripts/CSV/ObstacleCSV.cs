using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObstacleCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;     // �̵��ӵ�
	GameObject JumpOb;  // ��ֹ� ������
	GameObject SlideOb; // ��ֹ� ������
	protected string[] values;
	protected float x;
	protected float y;
	//protected float spawnTime = 2f;
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
		TextAsset csvFile = Resources.Load("CookieRunCSV") as TextAsset;
		string csvText = csvFile.text;
		Debug.Log(csvText);

		if (csvFile != null)
		{
			lines = csvText.Split('\n');
			StartCoroutine(ObstacleRoutine());
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

	IEnumerator ObstacleRoutine()
	{
		while (true)
		{
			foreach (string line in lines)
			{
				values = line.Split(',');   // ���� �����ڷ� �и��Ͽ� �� ���		*** string[] �̰� ���� (�׸��� ���� public���� �߰�)

				x = float.Parse(values[1]); //***** float 
				y = float.Parse(values[2]); //***** float	�̰� ���� (�׸��� ���� public���� �߰�)
				spawnTime = float.Parse(values[3]);

				if (values[0] == "JumpOb")
				{
					Instantiate(JumpOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
					Destroy(gameObject, 5f);
				}

				else if (values[0] == "SlideOb")
				{
					Instantiate(SlideOb, new Vector3(x, y, 0), Quaternion.identity);     // ���� ��ֹ� ����
					Destroy(gameObject, 5f);
				}

				yield return new WaitForSeconds(spawnTime);
			}
		}
	}
}

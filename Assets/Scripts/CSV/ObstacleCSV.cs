using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObstacleCSV : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 10.5f;    // �̵��ӵ�
	GameObject JumpOb;  // ��ֹ� ������
	GameObject SlideOb; // ��ֹ� ������
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
			Debug.LogError("CSV ������ �������� �ʽ��ϴ�: " + csvText);
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
	}
}

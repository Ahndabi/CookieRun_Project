using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
	private void Start()
	{
		ReadCSV();
	}

	void ReadCSV()
	{
		TextAsset csvFile = Resources.Load<TextAsset>("TestCookie");
		string csvText = csvFile.text;
		Debug.Log(csvText);

		//StreamReader reader = new StreamReader(csvText);


		/*
		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			string[] values = line.Split(',');

			string obstacleType = values[0];
			float positionX = float.Parse(values[1]);
			float positionY = float.Parse(values[2]);
			//float size = float.Parse(values[3]);
			//int scoreImpact = int.Parse(values[4]);

			// ��ֹ� �Ǵ� �������� �����ϰų� ��ġ�ϴ� ������ �����մϴ�.
			// ���� ���, Instantiate�� ����Ͽ� �ش� ��ġ�� ������Ʈ�� �����ϰų�, ���� ������ �ʿ��� ������ �����͸� �Ҵ��� �� �ֽ��ϴ�.

			// ����: ��ֹ� ����
			//
			//if (obstacleType == "Rock")
			//{
			//	GameObject rock = Instantiate(rockPrefab, new Vector3(positionX, positionY, 0));
			//}
		}*/
	}
}
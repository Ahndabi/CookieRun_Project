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

			// 장애물 또는 아이템을 생성하거나 배치하는 로직을 구현합니다.
			// 예를 들어, Instantiate를 사용하여 해당 위치에 오브젝트를 생성하거나, 게임 로직에 필요한 변수에 데이터를 할당할 수 있습니다.

			// 예시: 장애물 생성
			//
			//if (obstacleType == "Rock")
			//{
			//	GameObject rock = Instantiate(rockPrefab, new Vector3(positionX, positionY, 0));
			//}
		}*/
	}
}
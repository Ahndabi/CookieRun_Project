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
	[SerializeField] GameObject HeartLife;          // 아이템 프리팹
	[SerializeField] GameObject Magnet;				// 아이템 프리팹
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
        Magnet = Resources.Load<GameObject>("Prefabs/Item/Item_Magnet");
        HeartLife = Resources.Load<GameObject>("Prefabs/Item/HeartLife");
		JumpOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/JumpObstacle1");
		SlideOb = Resources.Load<GameObject>("Prefabs/Obstacle&ItemSet/SlideObstacle1");
	}

	void OnEnable()
	{
		CSVReader();
	}

	public void CSVReader()
	{
         TextAsset csvFile = Resources.Load("ALLCSV") as TextAsset;
        // TextAsset csvFile = Resources.Load("ALLCSV_Time") as TextAsset;
        string csvText = csvFile.text;

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
		StopCoroutine(CSVRoutine());
	}


    IEnumerator CSVRoutine()
    {
        yield return new WaitForSeconds(1f);
        WaitForSeconds itemSpawnTime = new WaitForSeconds(0.2f);    // 미리 캐싱하고 사용

        // lines[0]에는 아이템과 장애물이 무엇인지의 정보가 있고,
        // lines[1]부터 Instantiate 해주면 됨 그다음은 [2], [3] 이렇게
        // 프리팹 이름들이 있는 lines[0] 부분만 일단 가져오기

        int linesLength = lines.Length;

        for (int i = 1; i < linesLength; ++i)
        {
            values = lines[i].Split(',');

            int valuesLength = values.Length;

            for (int k  = 0; k < float.Parse(values[9]); ++k)   // 마지막 values[9] 값은 그 한 줄 장애물 패턴 반복 횟수. 그만큼 반복하도록.
            {
                for (int j = 0; j < valuesLength; ++j)      // 한 줄 생성
                {
                    InstantiateCSV(j);  // 아이템 생성하는 함수
                }
                yield return itemSpawnTime;
            }
        }
    }

    /*
	 *  아이템 생성하는 걸 함수로 만들고, 그 함수에 매개변수로 위의 value값을 받음. for(int ~~~~) { 함수() } 이렇게 하는데,
	 *  만약 마지막 values[9]이 > 2 라면 연속으로 생성되어야 하니까 InvokeRepeating(함수이름,  0.2, 0.2 * values[9])
	 */

    void InstantiateCSV(int number)
	{

        if (number == 0 && float.Parse(values[0]) != 0)      // values의 값이 0이 아니라면 생성
        {
            GameManager.Pool.Get<GameObject>(JumpOb, new Vector3(13, float.Parse(values[0]), 0), Quaternion.identity);
        }
        if (number == 1 && float.Parse(values[1]) != 0)
        {
            GameManager.Pool.Get<GameObject>(SlideOb, new Vector3(13, float.Parse(values[1]), 0), Quaternion.identity);
        }
        if (number == 2 && float.Parse(values[2]) != 0)
        {
            // <GameObject>(Blue, new Vector3(13, float.Parse(values[2]), 0), Quaternion.identity);
            Instantiate(Blue, new Vector3(13, float.Parse(values[2]), 0), Quaternion.identity);
        }
        if (number == 3 && float.Parse(values[3]) != 0)
        {
            // GameManager.Pool.Get<GameObject>(Bear, new Vector3(13, float.Parse(values[3]), 0), Quaternion.identity);
            Instantiate(Bear, new Vector3(13, float.Parse(values[3]), 0), Quaternion.identity);
        }
        if (number == 4 && float.Parse(values[4]) != 0)
        {
            GameManager.Pool.Get<GameObject>(Sliver, new Vector3(13, float.Parse(values[4]), 0), Quaternion.identity);
        }
        if (number == 5 && float.Parse(values[5]) != 0)
        {
            // GameManager.Pool.Get<GameObject>(Gold, new Vector3(13, float.Parse(values[5]), 0), Quaternion.identity);
            Instantiate(Gold, new Vector3(13, float.Parse(values[5]), 0), Quaternion.identity);
        }
        if (number == 6 && float.Parse(values[6]) != 0)
        {
            GameManager.Pool.Get<GameObject>(Bigger, new Vector3(13, float.Parse(values[6]), 0), Quaternion.identity);
        }
        if (number == 7 && float.Parse(values[7]) != 0)
        {
            GameManager.Pool.Get<GameObject>(HeartLife, new Vector3(13, float.Parse(values[7]), 0), Quaternion.identity);
        }
        if (number == 8 && float.Parse(values[8]) != 0)
        {
            GameManager.Pool.Get<GameObject>(Magnet, new Vector3(13, float.Parse(values[8]), 0), Quaternion.identity);
        }
    }


	/*
	void InstantiateOfCSV(int valueLengh)
    {
        if (j == 0 && float.Parse(values[0]) != 0)      // values의 값이 0이 아니라면 생성
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
        if (j == 8 && float.Parse(values[8]) != 0)
        {
            Instantiate(Magnet, new Vector3(13, float.Parse(values[8]), 0), Quaternion.identity);
        }
        if (j == 9 && float.Parse(values[9]) != 0)
        {
            yield return new WaitForSeconds(float.Parse(values[9]));
        }
    }*/
}

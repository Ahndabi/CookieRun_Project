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
	[SerializeField] GameObject HeartLife;          // ������ ������
	[SerializeField] GameObject Magnet;				// ������ ������
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
		StopCoroutine(CSVRoutine());
	}


    IEnumerator CSVRoutine()
    {
        yield return new WaitForSeconds(1f);
        WaitForSeconds itemSpawnTime = new WaitForSeconds(0.2f);    // �̸� ĳ���ϰ� ���

        // lines[0]���� �����۰� ��ֹ��� ���������� ������ �ְ�,
        // lines[1]���� Instantiate ���ָ� �� �״����� [2], [3] �̷���
        // ������ �̸����� �ִ� lines[0] �κи� �ϴ� ��������

        int linesLength = lines.Length;

        for (int i = 1; i < linesLength; ++i)
        {
            values = lines[i].Split(',');

            int valuesLength = values.Length;

            for (int k  = 0; k < float.Parse(values[9]); ++k)   // ������ values[9] ���� �� �� �� ��ֹ� ���� �ݺ� Ƚ��. �׸�ŭ �ݺ��ϵ���.
            {
                for (int j = 0; j < valuesLength; ++j)      // �� �� ����
                {
                    InstantiateCSV(j);  // ������ �����ϴ� �Լ�
                }
                yield return itemSpawnTime;
            }
        }
    }

    /*
	 *  ������ �����ϴ� �� �Լ��� �����, �� �Լ��� �Ű������� ���� value���� ����. for(int ~~~~) { �Լ�() } �̷��� �ϴµ�,
	 *  ���� ������ values[9]�� > 2 ��� �������� �����Ǿ�� �ϴϱ� InvokeRepeating(�Լ��̸�,  0.2, 0.2 * values[9])
	 */

    void InstantiateCSV(int number)
	{

        if (number == 0 && float.Parse(values[0]) != 0)      // values�� ���� 0�� �ƴ϶�� ����
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
        if (j == 0 && float.Parse(values[0]) != 0)      // values�� ���� 0�� �ƴ϶�� ����
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

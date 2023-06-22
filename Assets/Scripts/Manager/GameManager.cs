using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public const string DefaultName = "Manager";

	private static GameManager instance;
	private static DataManager dataManager;
	private static PoolManager poolManager;
	private static HPManager hpManager;

	public static GameManager Instance { get { return instance; } }
	public static DataManager Data { get { return dataManager; } }
	public static PoolManager Pool { get { return poolManager; } }
	public static HPManager HP { get { return hpManager; } }


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(this);
			return;
		}

		instance = this;
		DontDestroyOnLoad(this);
		InitManagers();
	}

	private void OnDestroy()
	{
		if (instance == this)
			instance = null;
	}

	private void InitManagers()
	{
		GameObject dataObj = new GameObject() { name = "DataManager" };
		dataObj.transform.SetParent(transform);
		dataManager = dataObj.AddComponent<DataManager>();

		GameObject poolObj = new GameObject();
		poolObj.name = "PoolManager";
		poolObj.transform.parent = transform;
		poolManager = poolObj.AddComponent<PoolManager>();

		GameObject hpObj = new GameObject() { name = "HPManager" };
		hpObj.transform.SetParent(transform);
		hpManager = hpObj.AddComponent<HPManager>();

	}
}
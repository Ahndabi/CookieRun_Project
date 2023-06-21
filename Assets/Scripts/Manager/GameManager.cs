using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO : RuntimeInitializeOnLoadMethod 이거 추가해줘야 함

public class GameManager : MonoBehaviour
{
	public const string DefaultName = "Manager";

	private static GameManager instance;
	private static DataManager dataManager;
	private static PoolManager poolManager;

	public static GameManager Instance { get { return instance; } }
	public static DataManager Data { get { return dataManager; } }
	public static PoolManager Pool { get { return poolManager; } }

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
	}
}
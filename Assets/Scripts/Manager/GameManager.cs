using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public const string DefaultName = "Manager";

	static GameManager instance;
	static DataManager dataManager;
	static PoolManager poolManager;
	static ResourceManager resource;
	static UIManager uiManager;
	static HPManager hpManager;

	public static GameManager Instance { get { return instance; } }
	public static DataManager Data { get { return dataManager; } }
	public static PoolManager Pool { get { return poolManager; } }
	public static ResourceManager Resource { get { return resource; } }
	public static UIManager UI { get { return uiManager; } }
	
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

		GameObject resourceObj = new GameObject();
		resourceObj.name = "ResourceManager";
		resourceObj.transform.parent = transform;
		resource = resourceObj.AddComponent<ResourceManager>();

		GameObject uiObj = new GameObject();
		uiObj.name = "UIManager";
		uiObj.transform.parent = transform;
		uiManager = uiObj.AddComponent<UIManager>();

		GameObject hpObj = new GameObject() { name = "HPManager" };
		hpObj.transform.SetParent(transform);
		hpManager = hpObj.AddComponent<HPManager>();

	}
}
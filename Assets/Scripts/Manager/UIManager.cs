using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
	private EventSystem eventSystem;

	private Canvas popUpCanvas;
	private Stack<PopUpUI> popUpStack;

	private Canvas windowCanvas;

	private Canvas inGameCanvas;

	// HP 관리
	public float maxHP = 100;
	public float curHP;


	private void Awake()
	{
		eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
		eventSystem.transform.parent = transform;

		popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
		popUpCanvas.gameObject.name = "PopUpCanvas";
		popUpCanvas.sortingOrder = 100;
		popUpStack = new Stack<PopUpUI>();

		windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");	// 아직 안씀
		windowCanvas.gameObject.name = "WindowCanvas";
		windowCanvas.sortingOrder = 10;

		// gameSceneCanvas.sortingOrder = 1;

		inGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");	// 아직 안씀
		inGameCanvas.gameObject.name = "InGameCanvas";
		inGameCanvas.sortingOrder = 0;
	}
	
	private void Start()
	{
		curHP = maxHP;      // 처음에는 Hp가 max여야 한다.
	}

	// 데미지를 받으면 hp가 감소한다. 
	public void TakeDamageHP(float damage)
	{
		curHP -= damage;
	}

	// HP가 0이 될 때까지 시간이 지나면서 계속 HP가 감소한다.
	public void ChangedHP()
	{
		curHP -= Time.deltaTime * 5;
	}


	public T ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
	{
		if (popUpStack.Count > 0)
		{
			PopUpUI prevUI = popUpStack.Peek();
			prevUI.gameObject.SetActive(false);
		}

		T ui = GameManager.Pool.GetUI<T>(popUpUI);
		ui.transform.SetParent(popUpCanvas.transform, false);
		popUpStack.Push(ui);

		// 캐릭터 움직임도 멈췄음 좋겠어서 Animator를 뺐음
		Time.timeScale = 0f;
		return ui;
	}

	public T ShowPopUpUI<T>(string path) where T : PopUpUI
	{
		T ui = GameManager.Resource.Load<T>(path);
		return ShowPopUpUI(ui);
	}

	public void ClosePopUpUI()
	{
		PopUpUI ui = popUpStack.Pop();
		GameManager.Pool.ReleaseUI(ui.gameObject);

		if (popUpStack.Count > 0)
		{
			PopUpUI curUI = popUpStack.Peek();
			curUI.gameObject.SetActive(true);
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void ClearPopUpUI()
	{
		while (popUpStack.Count > 0)
		{
			ClosePopUpUI();
		}
	}


	/*
	 * WindowUI랑 InGameUI는 아직 안 써서 주석해놨음
	 * 
	public T ShowWindowUI<T>(T windowUI) where T : WindowUI
	{
		T ui = GameManager.Pool.GetUI(windowUI);
		ui.transform.SetParent(windowCanvas.transform, false);
		return ui;
	}

	public T ShowWindowUI<T>(string path) where T : WindowUI
	{
		T ui = GameManager.Resource.Load<T>(path);
		return ShowWindowUI(ui);
	}

	public void SelectWindowUI<T>(T windowUI) where T : WindowUI
	{
		windowUI.transform.SetAsLastSibling();
	}

	public void CloseWindowUI<T>(T windowUI) where T : WindowUI
	{
		GameManager.Pool.ReleaseUI(windowUI.gameObject);
	}
	public void ClearWindowUI()
	{
		WindowUI[] windows = windowCanvas.GetComponentsInChildren<WindowUI>();

		foreach (WindowUI windowUI in windows)
		{
			GameManager.Pool.ReleaseUI(windowUI.gameObject);
		}
	}

	public T ShowInGameUI<T>(T gameUi) where T : InGameUI
	{
		T ui = GameManager.Pool.GetUI(gameUi);
		ui.transform.SetParent(inGameCanvas.transform, false);

		return ui;
	}

	public T ShowInGameUI<T>(string path) where T : InGameUI
	{
		T ui = GameManager.Resource.Load<T>(path);
		return ShowInGameUI(ui);
	}

	public void CloseInGameUI<T>(T inGameUI) where T : InGameUI
	{
		GameManager.Pool.ReleaseUI(inGameUI.gameObject);
	}

	public void ClearInGameUI()
	{
		InGameUI[] inGames = inGameCanvas.GetComponentsInChildren<InGameUI>();

		foreach (InGameUI inGameUI in inGames)
		{
			GameManager.Pool.ReleaseUI(inGameUI.gameObject);
		}
	}*/
}

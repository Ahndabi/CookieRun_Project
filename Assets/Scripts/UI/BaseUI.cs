using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
	protected Dictionary<string, RectTransform> transforms;
	protected Dictionary<string, Button> buttons;
	protected Dictionary<string, TMP_Text> texts;
	// TODO : add ui component

	protected virtual void Awake()
	{
		BindChildren();
	}

	protected virtual void BindChildren()
	{
		transforms = new Dictionary<string, RectTransform>();
		buttons = new Dictionary<string, Button>();
		texts = new Dictionary<string, TMP_Text>();

		// 전체 게임오브젝트를 순회
		// RectTransform은 모든 게임오브젝트에 있기 때문에 다 찾아짐.
		RectTransform[] children = GetComponentsInChildren<RectTransform>();
		foreach (RectTransform child in children)
		{
			string key = child.gameObject.name;

			if (transforms.ContainsKey(key))
				continue;

			transforms.Add(key, child);

			Button button = child.GetComponent<Button>();
			if (button != null)
				buttons.Add(key, button);

			TMP_Text text = child.GetComponent<TMP_Text>();
			if (text != null)
				texts.Add(key, text);
		}
	}

	public virtual void CloseUI()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
	[SerializeField] GameObject CheckObj;
	float checkTime = 8;    // 원래 10초인데 확인하기 빠르게 하려고 8초로 함


	private void Start()
	{
		CheckObj.SetActive(false);	// 일단 빈오브젝트는 false;
	}

	IEnumerator CheckTriggerRoutine()
	{
		while(true)
		{
			CheckObj.SetActive(true);	// 빈오브젝트 활성화시키고
			
			// 트리거 확인

			yield return new WaitForSeconds(checkTime);
		}	
	}
}

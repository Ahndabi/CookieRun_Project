using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
	[SerializeField] GameObject CheckObj;
	float checkTime = 8;    // ���� 10���ε� Ȯ���ϱ� ������ �Ϸ��� 8�ʷ� ��


	private void Start()
	{
		CheckObj.SetActive(false);	// �ϴ� �������Ʈ�� false;
	}

	IEnumerator CheckTriggerRoutine()
	{
		while(true)
		{
			CheckObj.SetActive(true);	// �������Ʈ Ȱ��ȭ��Ű��
			
			// Ʈ���� Ȯ��

			yield return new WaitForSeconds(checkTime);
		}	
	}
}

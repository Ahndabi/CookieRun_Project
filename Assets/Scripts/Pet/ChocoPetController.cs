using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoPetController : Pet
{
	float time = 10f;
	
	// 10�ʿ� �� ���� �տ� �����Ǿ� �ִ� ���� �� �ϳ��� ū ������ ������ �ٲ��� (�̶��� �ִϸ��̼� ��)
	// 10�ʿ� �� ���� �ϴ� �Ŵϱ� �ڷ�ƾ���� �ϴ� �� ������
	IEnumerator ChangeJellyRoutine()
	{
		while (true)
		{
			// �տ� �ִ� Ư�� ���������� �̵��ؼ� �� �������� ū ������ ������ �ٲ�
			// target�� �������� ����
			// transform.position = Vector3.MoveTowards(transform.position, destination, 1); Ȥ�� transform.position = Vector3.Slerp(transform.position, destination, 0.01f);
			

			yield return new WaitForSeconds(time);
		}
	}
}

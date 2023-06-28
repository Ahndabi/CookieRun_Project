using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoPetController : Pet
{
	float time = 10f;
	
	// 10초에 한 번씩 앞에 구현되어 있는 젤리 중 하나를 큰 곰돌이 젤리로 바꿔줌 (이때도 애니메이션 함)
	// 10초에 한 번씩 하는 거니까 코루틴으로 하는 게 좋을듯
	IEnumerator ChangeJellyRoutine()
	{
		while (true)
		{
			// 앞에 있는 특정 아이템으로 이동해서 그 아이템을 큰 곰돌이 젤리로 바꿈
			// target인 아이템을 만들어서
			// transform.position = Vector3.MoveTowards(transform.position, destination, 1); 혹은 transform.position = Vector3.Slerp(transform.position, destination, 0.01f);
			

			yield return new WaitForSeconds(time);
		}
	}
}

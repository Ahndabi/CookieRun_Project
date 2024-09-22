using System.Collections;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
	// 플레이어 하위 자식에 점프하기 위한 발판(콜라이더)이 따로 있기 때문에 스크립트도 따로 만들어줌

	Animator anim;
	PlayerController playerController;
	public bool isGround = false;
    static readonly int Land_animation = Animator.StringToHash("Land");

    private void Awake()
	{
		anim = GetComponentInParent<Animator>();
		playerController = GetComponentInParent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == 7)	// Ground 레이어
		{
			if (playerController.isJump == true)
            {
				// 밑의 조건을 거는 이유는 점프 중 데미지를 받은 경우 점프 애니메이션은 풀리는데 Land 애니메이션 트리거가 계속 발동되어 있어 나중에 점프할 때 꼬여버림.
				// 그래서 점프 애니메이션 중인 경우에만 착지했을 때 land 트리거 발동하도록 함.
				if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == PlayerController.jump1_animation || anim.GetCurrentAnimatorStateInfo(0).shortNameHash == PlayerController.jump2_animation)
					anim.SetTrigger(Land_animation);
            }

            isGround = true;
			playerController.isJump = false;
			playerController.oneJump = false;
        }
    }
}

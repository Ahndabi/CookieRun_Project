using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] PlayerBase playerBase;
	float jumpSpeed = 20;
	bool isGrounded = true;
	bool oneJump = false;       // 1단 점프를 한 번 했는지
	public bool isJump = false;

    public AudioClip jumpSound;
    public AudioClip slideSound;

	// 애니메이션 파라미터 string 해싱해놓고 사용
    static readonly int jump1_animation = Animator.StringToHash("Jump1");
	static readonly int jump2_animation = Animator.StringToHash("Jump2");
	static readonly int slide_animation = Animator.StringToHash("Slide");
	static readonly int move_animation = Animator.StringToHash("Move");

	private void Awake()
	{
		jumpSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_jump");
		slideSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_slide");
	}

	public void Jump()
	{
		// 2단 점프만 가능하도록 
		if (GroundCheck())       // 1. 바닥이면 점프가능
		{
			playerBase.anim.SetTrigger(jump1_animation);
			isJump = true;
			oneJump = true;      // 1단점프 true
			playerBase.rb.velocity = Vector2.up * jumpSpeed;
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}
		else if (!GroundCheck() && oneJump)     // 1. 공중이면서	2. 1단점프를 한 경우
		{
            playerBase.anim.SetTrigger(jump2_animation);
			isJump = true;
			oneJump = false;     // 1단 점프는 이미 했음
			playerBase.rb.velocity = Vector2.up * jumpSpeed;       // 한 번 더 점프 가능
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}
	}

	void OnJump(InputValue value)
	{
		Jump();
	}

	private bool GroundCheck()
	{
		// 바닥인지 체크하고 2단 점프만 가능하도록 해야함

		RaycastHit2D hit;

		// Bigger 상태면 레이캐스트를 2.5f로 해주고 기본 상태면 2f로 해줌
		// if (anim.GetCurrentAnimatorStateInfo(1).nameHash == Animator.StringToHash("Item Layer.Bigger"))
		if (playerBase.anim.GetCurrentAnimatorStateInfo(1).IsName("Item Layer.Bigger"))
        {
			hit = Physics2D.Raycast(transform.position, Vector2.down, 4f, LayerMask.GetMask("Ground"));
		}
		else
		{
			hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
		}


		if (hit.collider != null)	// 레이어 부딪힌 게 있는 경우
		{
			isGrounded = true;
			isJump = false;
			oneJump = false;		// 바닥이니까 1단점프를 false로
		}
		else 
			isGrounded = false;

		return isGrounded;
	}

	void OnSlide(InputValue value)
	{
		Slide();
	}

	public void Slide()
	{
		playerBase.anim.SetTrigger(slide_animation);
        SoundManager.instance.SFXPlay("cookie0001_slide", slideSound);
    }

    public void Move()
	{
		playerBase.anim.SetTrigger(move_animation);
	}
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] PlayerBase playerBase;
	[SerializeField] PlayerRoot playerRoot;
    float jumpSpeed = 20;
	public bool oneJump = false;       // 1단 점프를 한 번 했는지
	public bool isJump = false;

    public AudioClip jumpSound;
    public AudioClip slideSound;

	// 애니메이션 파라미터 string 해싱해놓고 사용
    public static readonly int jump1_animation = Animator.StringToHash("Jump1");
	public static readonly int jump2_animation = Animator.StringToHash("Jump2");
	static readonly int slide_animation = Animator.StringToHash("Slide");
	static readonly int slideExit_animation = Animator.StringToHash("SlideExit");

    private void Awake()
	{
		jumpSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_jump");
		slideSound = GameManager.Resource.Load<AudioClip>("Sound/cookie0001_slide");
	}

	public void Jump()
	{
        // 2단 점프만 가능하도록 
        if (playerRoot.isGround == true)       // 1. 바닥이면 점프가능
		{
			playerBase.anim.SetTrigger(jump1_animation);
			oneJump = true;      // 1단점프 true
			playerBase.rb.velocity = Vector2.up * jumpSpeed;
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}
		else if (playerRoot.isGround == false && oneJump)     // 1. 공중이면서	2. 1단점프를 한 경우
		{
            playerBase.anim.SetTrigger(jump2_animation);
            oneJump = false;     // 1단 점프는 이미 했음
			playerBase.rb.velocity = Vector2.up * jumpSpeed;       // 한 번 더 점프 가능
			SoundManager.instance.SFXPlay("cookie0001_jump", jumpSound);
		}

        isJump = true;
        playerRoot.isGround = false;
    }

    void OnJump(InputValue value)
	{
		Jump();
	}
	
	void OnSlide(InputValue value)
	{
		if (value.isPressed == true)
		{
			if (playerRoot.isGround == true)
				Slide();
		}
        // 밑에 애니메이션 "Slide"인 경우에만 트리거 발동을 하는 이유는 Slide 애니메이션 상태에서 데미지를 받으면 키를 뗐을 때
		// SlideExit 트리거가 체크된 상태가 지속돼서 후에 슬라이드 애니메이션이 잘 작동되지 않음
        else if (value.isPressed == false && playerBase.anim.GetCurrentAnimatorStateInfo(0).shortNameHash == slide_animation)
		{
			playerBase.anim.SetTrigger(slideExit_animation);
		}

	}

	public void Slide()
	{
		playerBase.anim.SetTrigger(slide_animation);
        SoundManager.instance.SFXPlay("cookie0001_slide", slideSound);
    }
}

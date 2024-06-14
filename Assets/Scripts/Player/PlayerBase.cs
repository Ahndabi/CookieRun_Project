using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public PlayerInput inputSystem;
    public bool isUnDamage; // 현재 데미지를 받지 않는 상태인지 (데미지를 받은 직후, 좀비가 죽고 부활한 직후)
    public static bool isDie;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<PlayerInput>();
        isDie = false;
        isUnDamage = false;
    }
}

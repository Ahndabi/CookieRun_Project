using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInput inputSystem;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<PlayerInput>();
    }

}

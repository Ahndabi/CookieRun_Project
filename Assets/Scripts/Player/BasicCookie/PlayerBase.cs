using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public Animator anim;
    public Rigidbody2D rb;
    public PlayerInput inputSystem;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<PlayerInput>();
    }

}

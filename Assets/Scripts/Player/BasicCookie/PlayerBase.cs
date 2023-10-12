using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    // HP
    // Animation
    
    public Animator anim;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }
}

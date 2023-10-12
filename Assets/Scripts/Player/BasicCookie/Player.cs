using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // HP
    // Animation
    
    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        this.Attack1();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void Attack1()
    {
        if (InputManager.instance.meleeAttack)
        {
            this.animator.SetTrigger("Attack1");
        }
    }
}
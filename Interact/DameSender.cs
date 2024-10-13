using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DameSender : MonoBehaviour
{
    public int dameAttack = 2;
    protected DameReceiver dameReceiver;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        this.dameReceiver = collision.gameObject.GetComponent<DameReceiver>();

        if (collision.gameObject.CompareTag("Player")) return;

    }
}

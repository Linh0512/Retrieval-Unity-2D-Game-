using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender_Range : DameSender
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.CompareTag("Enemy") && dameReceiver != null)
        {
            dameReceiver.Received(this.dameAttack);
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground0"))
        {
            Destroy(this.gameObject);
        }
    }
}

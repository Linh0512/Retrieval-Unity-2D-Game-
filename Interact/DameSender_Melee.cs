using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender_Melee : DameSender
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);


        if (collision.gameObject.CompareTag("Enemy") && dameReceiver != null && this.CheckAttack() == true)
        {        
            dameReceiver.Received(this.dameAttack);
        }
    }

    // Check if any attack animation is playing
    protected bool CheckAttack()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            return true;
        }
        return false;
    }
}


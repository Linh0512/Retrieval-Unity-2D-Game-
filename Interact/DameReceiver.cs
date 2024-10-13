using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameReceiver : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;
    public int hp = 4;
    public Animator animator;
    private float timeToDisappear = 0.7f;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        this.animator = GetComponent<Animator>();
    }
    public virtual void Received(int dame)
    {
        this.hp -= dame;
        if (this.hp <= 0)
        {
            this.animator.SetTrigger("Dead");
            Invoke("DestroyObj", this.timeToDisappear);
        }
    }

    protected void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}

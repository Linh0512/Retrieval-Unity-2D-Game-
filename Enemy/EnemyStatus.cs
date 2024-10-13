using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;
    public bool isDead = false;
    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }

    private void Update()
    {
        this.IsDead();
    }

    public virtual void IsDead()
    {
        if (this.enemyCtrl.dameReceiver.hp <= 0)
        {
            this.isDead = true;
        }
    }
}

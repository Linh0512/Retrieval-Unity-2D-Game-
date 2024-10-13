using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public EnemyStatus enemyStatus;
    public Spawner spawner;
    public DameReceiver dameReceiver;

    private void Awake()
    {
        this.spawner = GetComponent<Spawner>();
        this.dameReceiver = GetComponent<DameReceiver>();
        this.enemyStatus = GetComponent<EnemyStatus>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    //public string prefabName;
    //public EnemyCtrl enemyCtrl;

    public GameObject objectPrefab;
    public List<GameObject> objects = new List<GameObject>();
    private float spawnDelay = 5f;
    private float timer = 0;
    private void Awake()
    {        
        //this.enemyCtrl = GetComponent<EnemyCtrl>();
        this.objectPrefab.SetActive(false);
    }

    private void Update()
    {
        this.Spawn();
        this.DelObj();
    }
    protected void Spawn()
    {
        if(this.EnemiesIsDead() == false) return;
        //if(objects.Count > 0) return;
        this.timer += Time.deltaTime;
        if(this.timer < spawnDelay) return;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject obj = Instantiate(objectPrefab, pos, transform.rotation);
        obj.SetActive(true);
        this.objects.Add(obj);
        this.timer = 0;
    }

    protected void DelObj()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject obj = objects[i];
            if (obj == null)
            {
                objects.RemoveAt(i);
            }
        }
    }

    private bool EnemiesIsDead()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                EnemyStatus status = obj.GetComponent<EnemyStatus>();
                if (status != null && status.isDead == false)
                {
                    return false;
                }
            }
        }
        return true;
    }
}

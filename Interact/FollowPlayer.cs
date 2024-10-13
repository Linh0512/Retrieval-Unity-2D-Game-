using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform knifePos;
    public float disLimit = 0f;
    public float speed = 30f;
    public float randPos = 0;
    // Update is called once per frame
    private void Awake()
    {
        this.knifePos = GameObject.Find("FlyingKnifePos").transform;
    }
    void Update()
    {
        Follow();
    }

    protected void Follow()
    {
        Vector3 pos = this.knifePos.position;
        Vector3 distance = pos - transform.position;

        if (distance.magnitude >= disLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * disLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);
        }
    }
}

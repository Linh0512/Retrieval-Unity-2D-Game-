using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeflDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
    }

    protected void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float force = 20f;
    private Vector3 direction;
    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        this.GetMousePos();
        this.CalculateVelocity();
    }

    protected void GetMousePos()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    protected void CalculateVelocity()
    {
        // calculate the velocity and direction of bullet according to the mouse
        this.direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        this.RotateBullet();
    }

    protected void RotateBullet()
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }
}

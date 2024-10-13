using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 mousePos;
    private Camera mainCam;
    public List<GameObject> spawnKnifeList;
    public bool canFire;
    private float timer = 0f;
    public float timeBetweenFiring = 0.5f;
    public int maxBullet = 5;

    private void Awake()
    {
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletPrefab.SetActive(false);
    }

    private void Update()
    {
        this.GetMousePos();
        this.Shoot();
        this.Reload();
        this.DelBullet();
    }

    protected void GetMousePos()
    {
        this.mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    protected void Shoot()
    {
        if (InputManager.instance.knightFlyAttack && canFire)
        {
            this.Spawn();
        }
    }

    protected void Spawn()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        if (this.spawnKnifeList.Count >= maxBullet) return;
        GameObject knifePrefab = Instantiate(bulletPrefab, pos, transform.rotation);
        knifePrefab.SetActive(true);
        this.spawnKnifeList.Add(knifePrefab);
        canFire = false;
    }

    protected void Reload()
    {
        if (!canFire)
        {
            this.timer += Time.deltaTime;
        }
        if (this.timer > timeBetweenFiring)
        {
            this.canFire = true;
            this.timer = 0;
        }
    }

    protected void DelBullet()
    {
        for (int i = 0; i < spawnKnifeList.Count; i++)
        {
            GameObject bullet = this.spawnKnifeList[i];
            if (bullet == null)
            {
                spawnKnifeList.RemoveAt(i);
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
public class Weapon_Javelin :Weapon
{
    public float bulletSpeed=10;
    public GameObject bulletPrefab;
    private GameObject bulletGo;

    private void Start()
    {
        SpawnBullet();
    }
    public override void Attack()
    {
        bulletGo.GetComponent<Collider>().enabled=true;
        if(bulletGo!=null)
        {
            bulletGo.transform.SetParent(null);
            bulletGo.GetComponent<Rigidbody>().linearVelocity=transform.forward*bulletSpeed;
            bulletGo=null;
        }
        else
        {
            return;
        }
        Invoke("SpawnBullet",0.5f);
    }

    private void SpawnBullet()
    {
        bulletGo=GameObject.Instantiate(bulletPrefab,transform.position,transform.rotation);
        bulletGo.transform.SetParent(transform);
        bulletGo.GetComponent<Collider>().enabled=false;
    }
}

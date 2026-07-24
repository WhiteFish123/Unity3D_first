using UnityEngine;
using System.Collections.Generic;
public class Weapon_Javelin :Weapon
{
    public float bulletSpeed=10;
    public GameObject bulletPrefab;
    public override void Attack()
    {
        GameObject bulletGo=GameObject.Instantiate(bulletPrefab,transform.position,transform.rotation);
        bulletGo.GetComponent<Rigidbody>().linearVelocity=transform.forward*bulletSpeed;
    }
}

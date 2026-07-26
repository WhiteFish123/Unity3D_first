using UnityEngine;
using System.Collections.Generic;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    public int atkValue=30;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        Destroy(this.gameObject, 10f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Tag.PLAYER))
        {
            return;
        }
        
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        col.enabled = false;

        transform.parent=collision.gameObject.transform;
        Destroy(this.gameObject, 2f);

        if(collision.gameObject.CompareTag(Tag.ENEMY))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}

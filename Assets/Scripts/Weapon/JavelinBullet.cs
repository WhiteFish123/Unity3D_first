using UnityEngine;
using System.Collections.Generic;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }
    private void OnColliderEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        col.enabled = false;

        Destroy(gameObject, 1f);
    }
}

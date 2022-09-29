using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_G : Helper_G
{
    Vector3 lastVelocity;
    void Update()
    {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        if (collision.gameObject.tag == "Wall") rigidbody.velocity = direction * speed ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : Helper
{
    Vector3 lastVelocity;
    [SerializeField] float bounceForce;

    void Update()
    {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        if(collision.gameObject.tag == "Bounce") rigidbody.velocity = direction * bounceForce;
    }
}

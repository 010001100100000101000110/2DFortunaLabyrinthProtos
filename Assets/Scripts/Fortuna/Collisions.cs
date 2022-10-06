using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : Helper
{
    Vector3 lastVelocity;
    [SerializeField] float bounceForce;
    void Update()
    {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        if (collision.gameObject.tag == "Bounce")
        {
            rigidbody.velocity = direction * bounceForce;
            audioManager.PlayBoing();
        }
        if (collision.gameObject.tag == "Wall") rigidbody.velocity = direction * speed;
        if (collision.gameObject.tag == "Danger") eventMethods.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collect")
        {
            collision.gameObject.SetActive(false);
            eventMethods.Collected();
        }
    }
}

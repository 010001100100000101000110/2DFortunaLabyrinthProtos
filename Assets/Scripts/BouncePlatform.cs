using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] int bounceForce = 40;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    Vector2 GetTrajectory(Quaternion angle)
    {
        Vector2 trajectory;



    }
}

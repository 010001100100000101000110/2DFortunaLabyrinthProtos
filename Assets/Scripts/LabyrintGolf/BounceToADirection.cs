using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceToADirection : MonoBehaviour
{
    [SerializeField] float force;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
}

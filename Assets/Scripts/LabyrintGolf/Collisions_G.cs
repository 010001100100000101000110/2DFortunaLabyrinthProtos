using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_G : Helper_G
{
    Vector3 lastVelocity;
    [SerializeField] float bouncePadForce;
    float linearDrag;
    [SerializeField] float frictionDrag;

    private void Start()
    {
        linearDrag = rigidbody.drag;
    }
    void Update()
    {
        lastVelocity = rigidbody.velocity;        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        if (collision.gameObject.tag == "Wall") rigidbody.velocity = direction * speed ;
        if (collision.gameObject.tag == "Bounce") rigidbody.velocity = direction * bouncePadForce;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            transform.position = collision.gameObject.transform.position;
            movement.ResetMovement();
            StartCoroutine(HoleAnimation());            
        }

        if (collision.gameObject.tag == "Friction") rigidbody.drag = frictionDrag;

        if (collision.gameObject.tag == "Finish") eventMethods.GameFinished();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Friction")  rigidbody.drag = linearDrag;
    }

    IEnumerator HoleAnimation()
    {
        float elapsedTime = 0;
        float totalTime = 1.5f;
        Vector3 currentScale = transform.localScale;
        Vector3 endScale = new Vector3 (0, 0, 0);

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(currentScale, endScale, elapsedTime / totalTime);
            yield return null;
        }
        transform.position = movement.lastPosition;
        movement.ResetMovement();
        transform.localScale = currentScale;
    }
}

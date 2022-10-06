using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : Helper_G
{
    public GameObject partnerPortal;
    //[SerializeField] float teleportCooldownTime;

    public bool canTeleport;
    bool partnerCanTeleport;

    SpriteRenderer renderer;
    SpriteRenderer partnerRenderer;

    Collider2D collider;
    Collider2D partnerCollider;

    Color32 originalColor;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        partnerRenderer = partnerPortal.GetComponent<SpriteRenderer>();

        collider = GetComponent<Collider2D>();
        partnerCollider = partnerPortal.GetComponent<Collider2D>();


        canTeleport = true;
        originalColor = renderer.color;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.gameObject.tag == "Player")
        {
            renderer.color = Color.black;
            partnerRenderer.color = Color.black;
            canTeleport = false;
            partnerPortal.GetComponent<Teleportation>().canTeleport = false;
            audioHandler.PlayTeleport();

            collision.gameObject.transform.position = partnerPortal.transform.position;
        }
    }
    public void ReturnOriginalColor()
    {
        renderer.color = originalColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : Helper_G
{
    [SerializeField] GameObject partnerPortal;
    //[SerializeField] float teleportCooldownTime;

    public bool canTeleport;
    bool partnerCanTeleport;

    SpriteRenderer renderer;
    SpriteRenderer partnerRenderer;

    Collider2D collider;
    Collider2D partnerCollider;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        partnerRenderer = partnerPortal.GetComponent<SpriteRenderer>();

        collider = GetComponent<Collider2D>();
        partnerCollider = partnerPortal.GetComponent<Collider2D>();

        partnerCanTeleport = partnerPortal.GetComponent<Teleportation>().canTeleport;
        canTeleport = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = partnerPortal.transform.position;
            collider.enabled = false;
            partnerCollider.enabled = false;
            teleports.Add(this.gameObject);
            teleports.Add(partnerPortal);
            audioHandler.PlayTeleport();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canTeleport = false;
            partnerCanTeleport = false;
            renderer.color = Color.black;
            partnerRenderer.color = Color.black;
            //eventMethods.BallTeleported();
            //StartCoroutine(PortalCooldown());
        }
    }

    IEnumerator PortalCooldown()
    {
        float elapsedTime = 0;
        float totalTime = 4;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            renderer.color = Color32.Lerp(Color.black, Color.white, elapsedTime / totalTime);
            partnerRenderer.color = Color32.Lerp(Color.black, Color.white, elapsedTime / totalTime);
            yield return null;
        }
        canTeleport = true;
        partnerCanTeleport = true;
        partnerCollider.enabled = true;
        collider.enabled = true;
        
    } 
}

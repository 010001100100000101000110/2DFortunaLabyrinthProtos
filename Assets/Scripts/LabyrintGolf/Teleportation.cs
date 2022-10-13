using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : Helper_G
{
    public GameObject partnerPortal;
    Teleportation partnerTeleportation;
    //[SerializeField] float teleportCooldownTime;

    public bool canTeleport;
    bool partnerCanTeleport;

    SpriteRenderer renderer;
    SpriteRenderer partnerRenderer;

    CapsuleCollider2D collider;
    CapsuleCollider2D partnerCollider;

    Color32 originalColor;
    void Start()
    {
        partnerTeleportation = partnerPortal.GetComponent<Teleportation>();
        renderer = GetComponent<SpriteRenderer>();
        partnerRenderer = partnerPortal.GetComponent<SpriteRenderer>();

        collider = GetComponent<CapsuleCollider2D>();
        partnerCollider = partnerPortal.GetComponent<CapsuleCollider2D>();


        canTeleport = true;
        originalColor = renderer.color;

    }

    public void EnableTeleport()
    {
        Debug.Log("kys");
        
        renderer.color = originalColor;
        collider.enabled = true;
        canTeleport = true;
        tpEnabled = true;

        partnerRenderer.color = partnerTeleportation.originalColor;
        partnerCollider.enabled = true;
        partnerTeleportation.canTeleport = true;
        partnerTeleportation.tpEnabled = true;
    }

    [SerializeField]bool oneTimeUse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.gameObject.tag == "Player")
        {
            canTeleport = false;
            partnerPortal.GetComponent<Teleportation>().canTeleport = false;
            renderer.color = Color.black;
            partnerRenderer.color = Color.black;
            collider.enabled = false;
            partnerCollider.enabled = false;
            audioHandler.PlayTeleport();
            collision.gameObject.transform.position = partnerPortal.transform.position;
            tpEnabled = false;
            if (oneTimeUse)
            {
                partnerPortal.SetActive(false);
                gameObject.SetActive(false);
            }
       
        }
    }

    public bool tpEnabled;
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        EnableTeleport();
    //    }
    //}
    public void ReturnOriginalColor()
    {
        renderer.color = originalColor;
    }
}

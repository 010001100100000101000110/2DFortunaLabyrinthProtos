using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler_G : Helper
{
    LineRenderer line;
    Movement slingMovement;
    [SerializeField] Image image;

    float distance;
    bool canRenderLine;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        slingMovement = FindObjectOfType<Movement>();
    }

    void Update()
    {
        base.Update();
        distance = Vector3.Distance(player.transform.position, mousePosition);

        if (canRenderLine)
        {
            LineRendererTing();
            UpdateSlider();
        }
    }

    void LineRendererTing()
    {
        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, mousePosition);
    }

    public void CanLineRender()
    {
        canRenderLine = true;
        line.enabled = true;
    }

    public void CantLineRender()
    {
        canRenderLine = false;
        line.enabled = false;
    }

    void UpdateSlider()
    {
        image.fillAmount = distance / slingMovement.GetMaxDistance();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler_G : Helper_G
{
    LineRenderer line;
    [SerializeField] Image loadForceImage;
    [SerializeField] TMP_Text strokeCountingText;

    float distance;
    bool canRenderLine;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        UpdateStrokeAmount();
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
        loadForceImage.fillAmount = distance / movement.GetMaxDistance();
    }

    public void UpdateStrokeAmount()
    {
        strokeCountingText.text = "Strokes: " + movement.launchAmount.ToString();
    }
}

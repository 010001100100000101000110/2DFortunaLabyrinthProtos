using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : Helper
{
    LineRenderer line;
    SlingshotMovement slingMovement;
    [SerializeField] Image image;
    
    float distance;
    bool canRenderLine;

    [SerializeField] GameObject pickPositionPanel;
    [SerializeField] GameObject launchingModePanel;
    [SerializeField] GameObject ballActivePanel;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        ResetUIAtStart();
        line = GetComponent<LineRenderer>();
        slingMovement = FindObjectOfType<SlingshotMovement>();
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

    void ResetUIAtStart()
    {
        pickPositionPanel.SetActive(true);
        launchingModePanel.SetActive(false);
        ballActivePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
}

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
    
    bool canRenderLine;

    [SerializeField] GameObject pickPositionPanel;
    [SerializeField] GameObject launchingModePanel;
    [SerializeField] GameObject ballActivePanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TMP_Text collectedText;

    void Start()
    {
        ResetUIAtStart();
        line = GetComponent<LineRenderer>();
        slingMovement = FindObjectOfType<SlingshotMovement>();
        UpdateCollectedText();
    }

    void Update()
    {               
        if (canRenderLine)
        {
            LineRendererTing();
            UpdateSlider();
        }
    }

    void LineRendererTing()
    {
        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, GetMousePosition());
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
        image.fillAmount = GetDistance() / slingMovement.GetMaxDistance();
    }

    public void UpdateCollectedText()
    {
        collectedText.text = "collected drops: " + collecting.CollectedDrops.ToString();
    }

    void ResetUIAtStart()
    {
        pickPositionPanel.SetActive(true);
        launchingModePanel.SetActive(false);
        ballActivePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
}

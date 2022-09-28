using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetUIAtStart : MonoBehaviour
{
    [SerializeField] GameObject pickPositionPanel;
    [SerializeField] GameObject launchingModePanel;
    [SerializeField] GameObject ballActivePanel;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        pickPositionPanel.SetActive(true);
        launchingModePanel.SetActive(false);
        ballActivePanel.SetActive(false);
        gameOverPanel.SetActive(false); 
    }
}

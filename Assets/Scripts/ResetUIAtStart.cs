using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetUIAtStart : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject pickPositionPanel;
    [SerializeField] GameObject launchingModePanel;
    [SerializeField] GameObject ballActivePanel;

    void Start()
    {
        startPanel.SetActive(true);
        pickPositionPanel.SetActive(false);
        launchingModePanel.SetActive(false);
        ballActivePanel.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRechargeStations : MonoBehaviour
{
    GameObject[] rechargeStations;
    void Start()
    {
        rechargeStations = GameObject.FindGameObjectsWithTag("Recharge");
    }

    public void ActivateRechargeStations()
    {
        for (int i = 0; i < rechargeStations.Length; i++)
        {
            rechargeStations[i].SetActive(true);
        }
    }
}

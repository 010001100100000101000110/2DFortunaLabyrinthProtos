using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public int CollectedDrops { get; private set; }
    [SerializeField] GameObject[] collected;

    void Start()
    {
        collected = GameObject.FindGameObjectsWithTag("Collect");
    }
    public void AddToCollected()
    {
        CollectedDrops++;
    }

    public void SubtractFromCollected()
    {
        CollectedDrops--;
    }

    public void ResetCollectedAmount()
    {
        CollectedDrops = 0;
    }

    public void ResetCollectedActivity()
    {
        for (int i = 0; i < collected.Length; i++)
        {
            collected[i].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventListenerMethods : MonoBehaviour
{
    [SerializeField] GameEvent OnDecidingStartingPlace;
    [SerializeField] GameEvent OnStartingPlaceDecided;

    public void DecidingStartingPlace()
    {
        OnDecidingStartingPlace?.Raise();
    }

    public void StartingPlaceDecided()
    {
        OnStartingPlaceDecided?.Raise();
    }
}

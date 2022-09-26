using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventListenerMethods : MonoBehaviour
{
    [SerializeField] GameEvent OnDecidingStartingPlace;
    [SerializeField] GameEvent OnStartingPlaceDecided;

    [SerializeField] GameEvent OnResetButtonHit;
    [SerializeField] GameEvent OnBallLaunched;

    public void DecidingStartingPlace()
    {
        OnDecidingStartingPlace?.Raise();
    }

    public void StartingPlaceDecided()
    {
        OnStartingPlaceDecided?.Raise();
    }
    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }

    public void ResetBall()
    {
        OnResetButtonHit?.Raise();
    }
}

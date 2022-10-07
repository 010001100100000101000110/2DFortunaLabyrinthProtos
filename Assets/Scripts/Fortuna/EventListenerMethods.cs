using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventListenerMethods : MonoBehaviour
{   
    [SerializeField] GameEvent OnBallLaunched;
    [SerializeField] GameEvent OnGameOver;
    [SerializeField] GameEvent OnTryAgain;
    [SerializeField] GameEvent OnCollected;
    [SerializeField] GameEvent OnGameWon;

    
    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }   
    public void GameOver()
    {
        OnGameOver?.Raise();
    }
    public void TryAgain()
    {
        OnTryAgain?.Raise();
    }
    public void Collected()
    {
        OnCollected?.Raise();
    }
    public void GameWon()
    {
        OnGameWon?.Raise();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerMethods_G : MonoBehaviour
{
    [SerializeField] GameEvent OnBallLaunched;


    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }
}

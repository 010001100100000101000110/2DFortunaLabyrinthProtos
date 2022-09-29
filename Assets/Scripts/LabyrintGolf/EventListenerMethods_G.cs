using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerMethods_G : MonoBehaviour
{
    [SerializeField] GameEvent OnBallLaunched;
    [SerializeField] GameEvent OnBallStopped;
    [SerializeField] GameEvent OnBallTeleported;

    public void BallLaunched()
    {
        OnBallLaunched?.Raise();
    }
    public void BallStopped()
    {
        OnBallStopped?.Raise();
    }
    public void BallTeleported()
    {
        OnBallTeleported?.Raise();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void SetTimeScaleToZero()
    {
        Time.timeScale = 0;
    }

    public void SetTimeScaleToOne()
    {
        Time.timeScale = 1;
    }

}

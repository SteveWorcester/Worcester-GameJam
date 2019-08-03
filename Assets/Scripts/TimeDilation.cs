using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeDilation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DilateTimeForAbility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO: This needs to have an ability arg incoming, and used in while to stop dilation after ability cast 
    void DilateTimeForAbility()
    {
        float timeScaleAmount = .1f;
        double dilationTimerInRealtimeSeconds = 1;

        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (sw.Elapsed <= TimeSpan.FromSeconds(dilationTimerInRealtimeSeconds))
        {
            Time.timeScale = timeScaleAmount;
        }

    }
}

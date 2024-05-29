using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGetter : MonoBehaviour
{
    [SerializeField] private ScrollMechanic hours;
    [SerializeField] private ScrollMechanic minutes;
    [SerializeField] private ScrollMechanic time;
    private Action<string> getTime;
    public void Init(Action<string> action)
    {
        getTime = action;
    }
    public void GetTime()
    {
        string completedTime = hours.GetCurrentValueStr() + ":" + minutes.GetCurrentValueStr() + " " + time.GetCurrentValueStr();
        getTime?.Invoke(completedTime);
    }
}

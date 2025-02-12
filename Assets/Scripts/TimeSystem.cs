using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class TimeSystem
{
    public enum TimePeriod
    {
        Morning,
        Afternoon,
        Evening
    }

    public static event System.Action<TimePeriod> OnTimePeriodChanged;

    private static TimePeriod _currentTimePeriod = TimePeriod.Morning;
    public static TimePeriod CurrentTimePeriod
    {
        get => _currentTimePeriod;
        set
        {
            _currentTimePeriod = value;
            OnTimePeriodChanged?.Invoke(_currentTimePeriod);
        }
    }

}

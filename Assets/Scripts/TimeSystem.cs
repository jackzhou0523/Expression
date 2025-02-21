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

    private static int _currentDay = 1;
    public static int CurrentDay
    {
        get => _currentDay;
        set
        {
            _currentDay = value;
            OnDayChanged?.Invoke(_currentDay);
        }
    }

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

    public static event System.Action<int> OnDayChanged;
    public static event System.Action<TimePeriod> OnTimePeriodChanged;

    public static void AdvanceTime()
    {
        if (CurrentTimePeriod  == TimePeriod.Evening)
        {
            CurrentTimePeriod = TimePeriod.Morning;
            CurrentDay++;
        }
        else
        {
            CurrentTimePeriod++;
        }
    }

    public static void Reset()
    {
        CurrentDay = 1;
        CurrentTimePeriod = TimePeriod.Morning;
    }
    // public void TimePeriodChanged(TimePeriod timePeriod)
    // {
    //     if (OnTimePeriodChanged != null)
    //     {
    //         OnTimePeriodChanged(timePeriod);
    //     }
    // }

}

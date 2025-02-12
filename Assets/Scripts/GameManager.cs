using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance {get; private set;} // Singleton 
    public int currentDay = 1;  

    [Header("Progress System")]
    // public Dictionary<string, bool> unlockedLocations = new Dictionary<string, bool>();
    public List<LocationData> allLocations;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdvanceTime()
    {
        if (TimeSystem.CurrentTimePeriod == TimeSystem.TimePeriod.Evening)
        {
            currentDay++;
            TimeSystem.CurrentTimePeriod = TimeSystem.TimePeriod.Morning;
        }
        else
        {
            TimeSystem.CurrentTimePeriod++;
        }
    }

    // public void SaveGame()
    // {
    //     PlayerPrefs.SetInt("CurrentDay", currentDay);
    //     PlayerPrefs.SetInt("Currrent Period", (int)TimeSystem.CurrentTimePeriod);
    // }

    [Header("Flags")]
    public Dictionary<string, bool> _flagStates = new Dictionary<string, bool>();
    
    void InitializeFlags()
    {
        foreach (GameFlag flag in Resources.LoadAll<GameFlag>("Flags"))
        {
            _flagStates[flag.id] = flag.defaultState;
        }
    }

    public void SetFlag(string flagID, bool state)
    {
        if (_flagStates.ContainsKey(flagID))
        {
            _flagStates[flagID] = state;
            OnFlagChanged?.Invoke(flagID, state);
        }
        else
        {
            Debug.LogWarning("Flag with ID " + flagID + " not found!");
        }
    }

    public bool GetFlag(string flagID)
    {
        return _flagStates.TryGetValue (flagID, out bool state) ? state : false; 
    }

    public event System.Action<string, bool> OnFlagChanged;
}

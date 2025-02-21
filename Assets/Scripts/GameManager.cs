using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{      
    public static GameManager Instance {get; private set;} // Singleton  

    [Header("Progress System")]
    // public Dictionary<string, bool> unlockedLocations = new Dictionary<string, bool>();
    public List<LocationData> allLocations;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        TimeSystem.Reset();
        // TimeSystem.AdvanceTime();
    }

    // private void Start()
    // {
    //     gameObject.GetComponent<SceneFader>().InitializeSceneFader();
    // }
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

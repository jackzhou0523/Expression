using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UnlockConditions
{   
    public List<TimeSystem.TimePeriod> availableTimePeriod;
    public GameFlag requiredFlag;
    public bool requiredState = true;
}

[CreateAssetMenu(fileName = "New Location", menuName = "Game/LocationData")]
public class LocationData : ScriptableObject
{
    [Header("Basic Info")]
    public string locationID;
    public string locationName;
    // public Button locationButton;

    [Header("Scene Settings")]
    public string sceneName;

    [Header("3D Settings")]
    public GameObject locationPrefab;
    public Vector3 locationPosition;
    public Vector3 locationRotation;
    public Vector3 locationScale;

    // [Header("UI Settings")]
    // public Sprite uiIcon;
    // public Vector2 uiPosition;

    [Header("Visuals")]
    public Material hoverMaterial;
    public Material disabledMaterial;

    [Header("Unlock Conditions")]
    public List<UnlockConditions> unlockConditions;

    public bool IsUnlocked(Dictionary<string, bool> gameFlags)
    {   
        TimeSystem.TimePeriod currentPeriod = TimeSystem.CurrentTimePeriod;
        foreach (var condition in unlockConditions)
        {   
            if (!condition.availableTimePeriod.Contains(currentPeriod)) return false; // if the time period is not None and not the current time period, return false
            if (!gameFlags.ContainsKey(condition.requiredFlag.id)) return false; // if the flag is not in the dictionary, return false
            if (!gameFlags[condition.requiredFlag.id])  return false; // if the flag is false, return false
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{      
    public static MapManager Instance {get; private set;} // Singleton
    public Transform locationParent;
    private Dictionary<string, LocationController> spawnedLocations = new Dictionary<string, LocationController>();
    // public List<LocationData> locations;

    void Awake()
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
    }


    void Start()
    {      
        if (locationParent == null) // Add this check
        {
            locationParent = new GameObject("Locations").transform;
        }
        TimeSystem.OnTimePeriodChanged += OnTimePeriodChanged; // changing time period
        // GameManager.Instance.OnDayAdvanced += OnDayAdvanced; // changing the day
        GenerateMap(GameManager.Instance.allLocations);
    }

    void OnDestroy() {
        TimeSystem.OnTimePeriodChanged -= OnTimePeriodChanged;
        // GameManager.Instance.OnDayAdvanced -= OnDayChanged;
    }

     void GenerateMap(List<LocationData> locations)
     {
        foreach (LocationData data in locations)
        {   
            if (data.locationPrefab == null)
            {
                Debug.LogError($"Location {data.name} Prefab missing!");
                continue;
            }

            GameObject locationInstance = Instantiate(
                data.locationPrefab, 
                data.locationPosition, 
                Quaternion.Euler(data.locationRotation),
                locationParent);

            locationInstance.transform.localScale = data.locationScale;

            LocationController controller = locationInstance.GetComponent<LocationController>();
            if (controller == null)
            {
                Debug.LogError($"Prefab {data.locationPrefab.name} missing LocationController!");
                continue;
            }
            controller.Initialize(data);

            spawnedLocations.Add(data.locationID, controller);
        }
     }

    private void OnTimePeriodChanged(TimeSystem.TimePeriod currentTimePeriod)
    {
        Debug.Log("Time period changed to " + currentTimePeriod);
        UpdateAllLocations();
    }

    private void OnDayChanged(int currentDay)
    {
        Debug.Log("Day changed to " + currentDay);
        UpdateAllLocations();
    }

    public void UpdateAllLocations()
    {
        foreach (LocationController controller in spawnedLocations.Values)
        {
            controller.UpdateState();
        }
    }

}

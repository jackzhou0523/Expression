using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{      
    public static MapManager Instance {get; private set;} // Singleton
    public Transform locationParent;
    private Dictionary<string, LocationController> spawnedLocations = new Dictionary<string, LocationController>();
    // public List<LocationData> locations;
    private bool firstTime = true;

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
        // GenerateMap(GameManager.Instance.allLocations);
    }


    void Start()
    {   
        // TimeSystem.OnTimePeriodChanged += OnTimePeriodChanged; // changing time period
        // GameManager.Instance.OnDayAdvanced += OnDayAdvanced; // changing the day
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map")
        {   
            if (locationParent == null) // Add check
            {
                locationParent = new GameObject("Locations").transform;
            }
            GenerateMap(GameManager.Instance.allLocations);
        }
    }
    
    void OnDestroy() {
        // TimeSystem.OnTimePeriodChanged -= OnTimePeriodChanged;
        // GameManager.Instance.OnDayAdvanced -= OnDayChanged;
    }

    public void GenerateMap(List<LocationData> locations)
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
            
            // if (!firstTime)
            // {   
            //     return;
            // }

            // spawnedLocations.Add(data.locationID, controller);
        }
        firstTime = false;
        
    }

    // private void OnTimePeriodChanged(TimeSystem.TimePeriod currentTimePeriod)
    // {
    //     Debug.Log("Time period changed to " + currentTimePeriod);
    //     UpdateAllLocations();
    // }

    // private void OnDayChanged(int currentDay)
    // {
    //     Debug.Log("Day changed to " + currentDay);
    //     UpdateAllLocations();
    // }

    // public void UpdateAllLocations()
    // {
    //     foreach (LocationController controller in spawnedLocations.Values)
    //     {
    //         controller.UpdateState();
    //     }
    // }

}

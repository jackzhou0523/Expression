using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class UIManager : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject MapIcon;
    public GameObject PhoneUI;

    void Start()
    {
        
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActivateSceneUI(scene.name);
    }

    void ActivateSceneUI(string sceneName)
    {
        MenuUI.SetActive(false);
        MapIcon.SetActive(false);
        PhoneUI.SetActive(false);

        switch (sceneName)
        {
            case "Menu":
                MenuUI.SetActive(true);
                break;
            case "Map":
                // MapUI.SetActive(true);
                PhoneUI.SetActive(true);
                break;
            default: // Locations
                MapIcon.SetActive(true);
                PhoneUI.SetActive(true);
                // Debug.LogError($"No UI for scene {sceneName}");
                break;
        }
    }
}

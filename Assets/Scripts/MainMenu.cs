using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public void StartGame()
    {
        Debug.Log("Game started!");
        FindObjectOfType<SceneLoader>().FadeToSceneName("Dorm");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        Application.Quit();
    }

    public void MeettheTeam()
    {
        Debug.Log("Meet the team!");
    }
}

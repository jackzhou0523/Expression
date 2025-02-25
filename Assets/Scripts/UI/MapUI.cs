using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    public void OpenMap()
    {
        Debug.Log("Map opened!");
        FindObjectOfType<SceneLoader>().FadeToSceneName("Map");
        // StartCoroutine(UpdateMap());
    }

    // private IEnumerator UpdateMap()
    // {
    //     yield return null;
    //     MapManager.Instance.GenerateMap(GameManager.Instance.allLocations);
    // }
}

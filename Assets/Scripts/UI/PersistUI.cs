using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistUI : MonoBehaviour
{
    public static PersistUI Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Persist UI in the scene.");
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

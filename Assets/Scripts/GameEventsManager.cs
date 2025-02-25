using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    public InputEvents inputEvents;
    public DialogueEvents dialogueEvents;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            Destroy(gameObject);
        }
        Instance = this;

        // initialize all events
        inputEvents = new InputEvents();
        dialogueEvents = new DialogueEvents();
    }
}
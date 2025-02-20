using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{      
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJSON;
    private Story story;
    private int currentChoiceIndex = -1;
    private bool dialogueActive = false;

    private void Awake() 
    {
        story = new Story(inkJSON.text);
    }

    private void OnEnable() 
    {
        StartCoroutine(WaitForGameEventsManager());
    }

    private IEnumerator WaitForGameEventsManager()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }

        if (GameEventsManager.Instance.dialogueEvents == null)
        {
            Debug.LogError("GameEventsManager.Instance.dialogueEvents is null");
            yield break;
        }

        GameEventsManager.Instance.dialogueEvents.OnDialogueEvent += EnterDialogue;
        GameEventsManager.Instance.inputEvents.OnPressed += DialoguePressed;
        GameEventsManager.Instance.dialogueEvents.OnUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable() 
    {
        GameEventsManager.Instance.dialogueEvents.OnDialogueEvent -= EnterDialogue;
        GameEventsManager.Instance.inputEvents.OnPressed -= DialoguePressed;
        GameEventsManager.Instance.dialogueEvents.OnUpdateChoiceIndex -= UpdateChoiceIndex;
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
        ContinueOrExitStory();
    }

    private void DialoguePressed(InputEventContext inputEventContext)
    {   
        // if not in dialogue context, return
        if (!inputEventContext.Equals(InputEventContext.DIALOGUE))
        {
            return;
        }
        if (!dialogueActive)
        {
            return;
        }
        ContinueOrExitStory();
    }

    private void EnterDialogue(string knotName)
    {   
        if (dialogueActive)
        {
            return;
        }
        dialogueActive = true;

        GameEventsManager.Instance.dialogueEvents.DialogueStarted();
        // freeze the UI's

        //input event context to dialogue
        GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DIALOGUE);
        
        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName); // jump  to that point
        }
        else
        {
            Debug.LogWarning("Dialogue Knot Name is empty!");
        }

        // continue the story
        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {   
        // if there are choices, choose the choice
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {   
            Debug.Log("Choosing choice index: " + currentChoiceIndex);
            story.ChooseChoiceIndex(currentChoiceIndex);
            //reset choice index
            currentChoiceIndex = -1;
        }

        if (story.canContinue)
        {
            string dialogueline = story.Continue();
            GameEventsManager.Instance.dialogueEvents.DisplayDialogue(dialogueline, story.currentChoices);
        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {   
        Debug.Log("Exiting Dialogue");
        dialogueActive = false;

        GameEventsManager.Instance.dialogueEvents.DialogueFinished();
        // Enable the UI's

        //input event context back to default
        GameEventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DEFAULT);

        // reset story state
        story.ResetState();
    }
}

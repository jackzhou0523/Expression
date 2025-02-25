using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Runtime.CompilerServices;

public class DialogueManager : MonoBehaviour
{      
    public static DialogueManager Instance {get; private set;} // Singleton
    
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJSON;
    private Story story;
    private int currentChoiceIndex = -1;
    private bool dialogueActive = false;
    private InkDialogueVariables inkDialogueVariables;
    private const string SPEAKER_TAG = "speaker";
    // private const string PORTRAIT_TAG = "portrait";
    // private const string LAYOUT_TAG = "layout";
    private string speakerName;
    // private string portrait;
    // private string layout;
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
        story = new Story(inkJSON.text);
        inkDialogueVariables = new InkDialogueVariables(story);
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
        GameEventsManager.Instance.dialogueEvents.OnUpdateInkDialogueVariables += UpdateInkVariable;
    }

    private void OnDisable() 
    {
        GameEventsManager.Instance.dialogueEvents.OnDialogueEvent -= EnterDialogue;
        GameEventsManager.Instance.inputEvents.OnPressed -= DialoguePressed;
        GameEventsManager.Instance.dialogueEvents.OnUpdateChoiceIndex -= UpdateChoiceIndex;
        GameEventsManager.Instance.dialogueEvents.OnUpdateInkDialogueVariables -= UpdateInkVariable;
    }

    private void UpdateInkVariable(string variableName, Ink.Runtime.Object variableValue)
    {
        inkDialogueVariables.UpdateVariableState(variableName, variableValue);
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
        // if (canContinueToNextLine)
        // {
        //     ContinueOrExitStory();
        // }
        ContinueOrExitStory();
    }

    private void EnterDialogue(string knotName)
    {   
        if (dialogueActive ||!CheckKnotExists(knotName))
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


        // set the ink variables
        inkDialogueVariables.SyncVariableAndStartListening(story);

        // continue the story
        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {   
        bool canContinueToNextLine = FindObjectOfType<DialoguePanelUI>().getCanContinueToNextLine();
        // if there are choices, choose the choice
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {   
            Debug.Log("Choosing choice index: " + currentChoiceIndex);
            story.ChooseChoiceIndex(currentChoiceIndex);
            //reset choice index
            currentChoiceIndex = -1;
        }
        
        if (story.canContinue && canContinueToNextLine) 
        {   
            string dialogueline = story.Continue();

            HandleTags(story.currentTags);

            // skip blank lines
            while (IsLineBlank(dialogueline) && story.canContinue)
            {
                dialogueline = story.Continue();
            }

            // if the line is blank and there are no more choices, exit dialogue
            if (IsLineBlank(dialogueline) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                GameEventsManager.Instance.dialogueEvents.DisplayDialogue(speakerName, dialogueline, story.currentChoices);
            }
        }
        else if (story.currentChoices.Count == 0 && !story.canContinue)
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


        // stop listening to ink variables
        inkDialogueVariables.StopListening(story);

        // reset story state
        story.ResetState();
    }

    private bool IsLineBlank(string line)
    {
        return line.Trim().Equals("") || line.Trim().Equals("\n");
    }

    private void HandleTags(List<string> currenttags)
    {
        foreach (string tag in currenttags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogWarning("Invalid tag: " + tag);
                continue;
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    Debug.Log("Speaker: " + tagValue);
                    speakerName = tagValue;
                    break;
                // case PORTRAIT_TAG:
                //     portrait = tagValue;
                //     break;
                // case LAYOUT_TAG:
                //     layout = tagValue;
                //     break;
                default:
                    Debug.LogWarning("Tag not handled" + tag);
                    break;
            }
        }
    }

    public bool CheckKnotExists(string knotName)
    {
        try
        {
            story.ChoosePathString(knotName);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}

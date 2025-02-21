using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Ink.Runtime;

public class DialogueEvents
{
    public event Action<string> OnDialogueEvent;
    public void EnterDialogue(string knotName)
    {
        if (OnDialogueEvent != null)
        {
            OnDialogueEvent(knotName);
        }
    }

    public event Action OnDialogueStarted;

    public void DialogueStarted()
    {
        if (OnDialogueStarted != null)
        {
            OnDialogueStarted();
        }
    }

    public event Action OnDialogueFinished;
    public void DialogueFinished()
    {
        if (OnDialogueFinished != null)
        {
            OnDialogueFinished();
        }
    }

    public event Action<string, string, List<Choice>> OnDisplayDialogue;
    public void DisplayDialogue(string speakerName, string dialogueLine, List<Choice> dialoguechoices)
    {
        if (OnDisplayDialogue != null)
        {
            OnDisplayDialogue(speakerName, dialogueLine, dialoguechoices);
        }
    }

    public event Action<int> OnUpdateChoiceIndex;
    public void UpdateChoiceIndex(int choiceIndex)
    {
        if (OnUpdateChoiceIndex != null)
        {
            OnUpdateChoiceIndex(choiceIndex);
        }
    }

    public event Action<string, Ink.Runtime.Object> OnUpdateInkDialogueVariables;
    public void UpdateInkDialogueVariables(string variableName, Ink.Runtime.Object variableValue)
    {
        if (OnUpdateInkDialogueVariables != null)
        {
            OnUpdateInkDialogueVariables(variableName, variableValue);
        }
    }

}

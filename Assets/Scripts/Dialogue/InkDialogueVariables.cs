using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Rendering;

public class InkDialogueVariables 
{
    private Dictionary<string, Ink.Runtime.Object> inkVariables;

    public InkDialogueVariables(Story story)
    {
        inkVariables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string variableName in story.variablesState)
        {
            Ink.Runtime.Object variableValue = story.variablesState.GetVariableWithName(variableName);
            inkVariables.Add(variableName, variableValue);
            Debug.Log("Variable name: " + variableName + " Variable value: " + variableValue);
        }
    }

    public void SyncVariableAndStartListening(Story story)
    {   
        // before assigning the event, sync the variables
        SyncVariablesToStory(story);
        story.variablesState.variableChangedEvent += UpdateVariableState;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= UpdateVariableState;
    }

    public void UpdateVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (!inkVariables.ContainsKey(variableName))
        {
            return;
        }
        inkVariables[variableName] = variableValue;
        Debug.Log("Variable name: " + variableName + " Variable value: " + variableValue);
    }

    private void SyncVariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in inkVariables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}

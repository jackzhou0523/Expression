using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueChoiceButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public Button button;
    [SerializeField] private TextMeshProUGUI choiceText;
    [SerializeField] private int choiceIndex = -1;

    private void Awake() 
    {   
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
            Debug.Log("Button onClick event registered.");
        }
        else
        {
            Debug.LogError("Button component is missing.");
        }
    }
    public void SetChoiceText(string text)
    {
        choiceText.text = text;
    }

    public void SetChoiceIndex(int choiceIndex)
    {
        this.choiceIndex = choiceIndex;
    }

    public void OnClick()
    {   
        Debug.Log("Choice made: " + choiceText.text);
        GameEventsManager.Instance.dialogueEvents.UpdateChoiceIndex(choiceIndex);
    }

}

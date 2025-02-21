using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;
    // private const string SPEAKER_TAG = "speaker";
    // private const string PORTRAIT_TAG = "portrait";
    // private const string LAYOUT_TAG = "layout";

    private void Awake()
    {
        contentParent.SetActive(false);
        ResetPanel();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnDialogueStarted += DialogueStarted;
        GameEventsManager.Instance.dialogueEvents.OnDialogueFinished += DialogueFinished;
        GameEventsManager.Instance.dialogueEvents.OnDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnDialogueStarted -= DialogueStarted;
        GameEventsManager.Instance.dialogueEvents.OnDialogueFinished -= DialogueFinished;
        GameEventsManager.Instance.dialogueEvents.OnDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);

        //reset panel
        ResetPanel();
    }

    private void DisplayDialogue(string speakerName, string dialogueLine, List<Choice> dialogueChoices)
    {   
        dialogueText.text = dialogueLine;
        speakerNameText.text = speakerName;


        // if there are more choices than buttons, only display the first few choices
        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("Too many choices to display!");
        }

        foreach (DialogueChoiceButton choicebutton in choiceButtons)
        {
            choicebutton.gameObject.SetActive(false);
        }

        // display the choices
        int choicebuttonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialoguechoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choicebuttonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialoguechoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);
            
            choiceButton.button.onClick.RemoveAllListeners();
            choiceButton.button.onClick.AddListener(() => choiceButton.OnClick());

            if (inkChoiceIndex == 0)
            {
                EventSystem.current.SetSelectedGameObject(choiceButton.gameObject);
            }
            choicebuttonIndex--;
        }




    }

    private void ResetPanel()
    {
        dialogueText.text = "";
        speakerNameText.text = "";
    }
}

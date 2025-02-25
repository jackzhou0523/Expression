using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialoguePanelUI : MonoBehaviour
{   
    [Header("Typing Speed")]
    [SerializeField] private float typingspeed = 0.03f;
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;
    // [SerializeField] private Animator portraitAnimator;

    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = true;
    private bool isTyping = false;
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

    public bool getCanContinueToNextLine()
    {
        return canContinueToNextLine;
    }

    private void hideChoices()
    {
        foreach (DialogueChoiceButton choicebutton in choiceButtons)
        {
            choicebutton.gameObject.SetActive(false);
            // choicebutton.button.OnDeselect(null);
        }
    }

    private void choiceDisplay(List<Choice> dialogueChoices)
    {
        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("Too many choices to display!");
        }
        hideChoices();
        // display the choices
        int choicebuttonIndex = dialogueChoices.Count -1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialoguechoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choicebuttonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialoguechoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);
            
            choiceButton.button.onClick.RemoveAllListeners();
            choiceButton.button.onClick.AddListener(() => choiceButton.OnClick());

            // hover state for the keyboard
            // if (inkChoiceIndex == 0)
            // {
            //     EventSystem.current.SetSelectedGameObject(choiceButton.gameObject);
            // }
            choicebuttonIndex--;
        }
    }

    private IEnumerator DisplayLine(string line, List<Choice> dialogueChoices)
    {   
        // epmty the dialogue text
        dialogueText.text = "";

        // hide items while text is typing
        continueIcon.SetActive(false);
        hideChoices();

        canContinueToNextLine = false;

        foreach (char letter in line)
        {   
            // GameEventsManager.Instance.inputEvents.Pressed += () => isTyping = true;
            // if (isTyping)
            // {
            //     dialogueText.text = line;
            //     break;
            // }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
        
        // show items after text is done typing
        continueIcon.SetActive(true);
        choiceDisplay(dialogueChoices);

        canContinueToNextLine = true;
        isTyping = false;
    }

    
    private void DisplayDialogue(string speakerName, string dialogueLine, List<Choice> dialogueChoices)
    {   
        if (canContinueToNextLine)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(dialogueLine, dialogueChoices));
        }
        else
        {
            StopCoroutine(displayLineCoroutine);
            dialogueText.text = dialogueLine;
            canContinueToNextLine = true;
        }

        speakerNameText.text = speakerName;
    }


    private void ResetPanel()
    {
        dialogueText.text = "";
        speakerNameText.text = "";
    }

}

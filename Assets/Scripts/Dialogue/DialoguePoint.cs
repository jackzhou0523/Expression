using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialoguePoint : MonoBehaviour
{
    [Header("Dialogue Point")]
    [SerializeField] private string dialogueKnotName;

    private Collider interactionCollider;

    private void Awake()
    {
        interactionCollider = GetComponent<Collider>();
        if (interactionCollider == null)
        {
            Debug.LogError($"Prefab {gameObject.name} missing Collider component！");
        }
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.inputEvents.OnPressed += Pressed;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.inputEvents.OnPressed -= Pressed;
    }

    void Pressed(InputEventContext inputEventContext)
    {
        if (!inputEventContext.Equals(InputEventContext.DEFAULT))
        {
            return;
        }

        if (IsMouseOver())
        {
            if (!string.IsNullOrEmpty(dialogueKnotName))
            {
                GameEventsManager.Instance.dialogueEvents.EnterDialogue(dialogueKnotName);
            }
            else
            {
                Debug.LogError("Dialogue Point Knot Name is empty!");
            }
        }
    }

    private bool IsMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider == interactionCollider;
        }
        return false;
    }
}
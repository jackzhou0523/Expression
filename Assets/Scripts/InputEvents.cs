using UnityEngine;
using System;

public class InputEvents
{
    public InputEventContext inputEventContext { get; private set; } = InputEventContext.DEFAULT;

    public void ChangeInputEventContext(InputEventContext newContext) 
    {
        this.inputEventContext = newContext;
    }

    public event Action<InputEventContext> OnPressed;
    public void Pressed()
    {
        if (OnPressed != null) 
        {
            OnPressed(this.inputEventContext);
        }
    }
}
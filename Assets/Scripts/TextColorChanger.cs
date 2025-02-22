using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorChanger : MonoBehaviour
{
    private TextMeshProUGUI text;
    public Color defaultColor = Color.white;
    public Color changedColor = Color.red;

    public void ChangeColor()
    {   
        text = GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.color = changedColor;
        }
    }

    public void ResetColor()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.color = defaultColor;
        }
    }
}

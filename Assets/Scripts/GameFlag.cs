using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFlag", menuName = "Game/Flag")]
public class GameFlag : ScriptableObject
{
    public string id;
    public FlagCategory flagCategory;
    [TextArea] public string flagDescription;
    public bool defaultState = false;
}

public enum FlagCategory
{
    Location, // unlock locations
    Dialogue, // unlock dialogues
    Character, // unlock character's interactions?
    Item // unlock items
}
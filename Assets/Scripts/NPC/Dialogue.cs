using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 5)]
    public string[] sentences;
}

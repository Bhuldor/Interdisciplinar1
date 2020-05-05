using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 5)]
    public string[] sentences;

    public string GetLastSentence()
    {
        return sentences[sentences.Length-1];
    }
}

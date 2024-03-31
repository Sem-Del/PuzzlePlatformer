using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public Message[] messages;
    public Char[] characters;

    public void startDialogue()
    {
        FindObjectOfType<DialogueManger>().OpenDialogue(messages, characters);
    }
}

[System.Serializable]
public class Message
{
    public int charId;
    public string message;
}

[System.Serializable]
public class Char
{
    public string name;
}
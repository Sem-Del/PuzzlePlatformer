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
































//public TextMeshProUGUI textComponent;
//public string[] lines;
//public float textSpeed;

//private int index;

//void Start()
//{
//    textComponent.text = string.Empty;
//    startDialog();
//}

//// Update is called once per frame
//void Update()
//{
//    
//}

//void startDialog()
//{
//    index = 0;
//    StartCoroutine(Typeline());
//}

//IEnumerator Typeline()
//{
//    foreach (char c in lines[index].ToCharArray())
//    {
//        textComponent.text += c;
//        yield return new WaitForSeconds(textSpeed);
//    }
//}

//void NextLine()
//{
//    if (index < lines.Length - 1)
//    {
//        index++;
//        textComponent.text = string.Empty;
//        StartCoroutine (Typeline());
//    }else
//    {
//        gameObject.SetActive(false);
//    }
//}
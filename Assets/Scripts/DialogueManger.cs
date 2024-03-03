using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManger : MonoBehaviour
{

    public TextMeshProUGUI charName;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI continueText;
    public RectTransform backgroundBox;
    public Image backgroundImage;

    Message[] currentMessages;
    Char[] currentCharacters;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Char[] characters){
        currentMessages = messages;
        currentCharacters = characters;
        activeMessage = 0;
        isActive = true;
        SetDialogueOpacity(1f);
        Debug.Log("Started conversation loaded a total of: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        if (currentMessages == null || currentMessages.Length <= activeMessage ||
            currentCharacters == null || currentMessages[activeMessage].charId >= currentCharacters.Length)
        {
            Debug.LogError("Invalid state for displaying message.");
            return;
        }

        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Char characterToDisplay = currentCharacters[messageToDisplay.charId];
        charName.text = characterToDisplay.name;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        } else {
            SetDialogueOpacity(0f);
            isActive = false;
        }
    }

    void SetDialogueOpacity(float alpha)
    {
        Color backgroundColor = backgroundImage.color;
        backgroundColor.a = alpha;
        backgroundImage.color = backgroundColor;

        Color nameColor = charName.color;
        nameColor.a = alpha;
        charName.color = nameColor;

        Color messageColor = messageText.color;
        messageColor.a = alpha;
        messageText.color = messageColor;

        Color continueColor = continueText.color;
        continueColor.a = alpha;
        continueText.color = continueColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetDialogueOpacity(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }
}

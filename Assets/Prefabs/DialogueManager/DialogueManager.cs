using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{


    private static DialogueManager _instance;
    public static DialogueManager GetInstance() => _instance;

    private Queue<string> sentences;
    private Dialogue _currentDialogue;

    public Text conversationTitle;
    public Text conversationText;
    public Canvas dialogCanvas;

    
    private void Awake()
    {
         if (_instance != null && _instance != this)
        {
            Destroy(this);
        } else {
            _instance = this;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _currentDialogue = dialogue;
        Debug.Log("Set canvas active");
        dialogCanvas.gameObject.SetActive(true);
        Debug.Log($"Starting conversation with {dialogue.name}");
        conversationTitle.text = dialogue.name;
        sentences = new Queue<string>(dialogue.sentences);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentences.Dequeue();

        Debug.Log(currentSentence);
        conversationText.text = currentSentence;
    }

    public void EndDialogue()
    {
        Debug.Log("Ende der Konversation");
        conversationTitle.text = "";
        conversationText.text = "";
        dialogCanvas.gameObject.SetActive(false);
        _currentDialogue.AfterDialogFinishedEvent?.Invoke();
        
    }
}

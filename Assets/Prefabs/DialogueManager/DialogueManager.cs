using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{


    private static DialogueManager _instance;
    public static DialogueManager GetInstance() => _instance;

    private string[] sentences;
    private int currentSentenceIndex = 0;
    private Dialogue _currentDialogue;

    public Text conversationTitle;
    public Text conversationText;
    public Canvas dialogCanvas;

    public Animator animator;

    
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
        //dialogCanvas.gameObject.SetActive(true);
        animator.SetBool("IsOpen", true);
        Debug.Log($"Starting conversation with {dialogue.name}");
        conversationTitle.text = dialogue.name;
        sentences = dialogue.sentences;

        DisplaySentence(0);
    }

    public void DisplaySentence(int index) {
        string currentSentence = sentences[index];
        Debug.Log(index);
        string userName = PlayerPrefs.GetString("userName", "007");
        string userTitle = PlayerPrefs.GetString("userTitle", "Agentin");
        string smallUserTitle = userTitle.ToLower();
        conversationText.text = String.Format(currentSentence, userName, userTitle, smallUserTitle);
    }

    public void DisplayPrevSentence() {
        if (currentSentenceIndex == 0)
        {
            return;
        }

        DisplaySentence(--currentSentenceIndex);
    }

    public void DisplayNextSentence()
    {
        if(currentSentenceIndex == sentences.Length - 1)
        {
            EndDialogue();
            return;
        }

        DisplaySentence(++currentSentenceIndex);
    }

    public void EndDialogue()
    {
        Debug.Log("Ende der Konversation");
        conversationTitle.text = "";
        conversationText.text = "";
        //dialogCanvas.gameObject.SetActive(false);
        animator.SetBool("IsOpen", false);
        _currentDialogue.AfterDialogFinishedEvent?.Invoke();
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private string[] sentences;

    private UnityEngine.AudioClip[] voices;
    private string[] confirmatoryStatements;
    private int _currentIndex = 0;
    private Dialogue _currentDialogue;
    private Button _currentPrevButton;

    public Text conversationTitle;
    public Text conversationText;
    public Canvas dialogCanvas;

    public Animator animator;

    public AudioSource audioSource;

    public void StartDialogue(Dialogue dialogue, Button prevButton)
    {
        _currentDialogue = dialogue;
        _currentPrevButton = prevButton;
        _currentIndex = 0;
        Debug.Log("Set canvas active");
        //dialogCanvas.gameObject.SetActive(true);
        animator.SetBool("IsOpen", true);
        Debug.Log($"Starting conversation with {dialogue.name}");
        conversationTitle.text = dialogue.name;
        sentences = dialogue.sentences;
        voices = dialogue.voices;

        DisplaySentence();
        PlayAudio();
    }

    public void PlayAudio() {
        AudioClip currentAudio = voices[_currentIndex];
        audioSource.clip = currentAudio;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void DisplaySentence() {
        string currentSentence = sentences[_currentIndex];
        Debug.Log(_currentIndex);
        string userName = PlayerPrefs.GetString("userName", "007");
        string userTitle = PlayerPrefs.GetString("userTitle", "Agentin");
        string smallUserTitle = userTitle.ToLower();
        conversationText.text = String.Format(currentSentence, userName, userTitle, smallUserTitle);

        // Hide prev button on start
        _currentPrevButton?.gameObject.SetActive(_currentIndex != 0);
    }

    public void DisplayPrevSentence() {
        if (_currentIndex == 0)
        {
            return;
        }

        _currentIndex--;
        DisplaySentence();
        PlayAudio();
    }

    public void DisplayNextSentence()
    {
        if(_currentIndex == sentences.Length - 1)
        {
            EndDialogue();
            return;
        }

        _currentIndex++;
        DisplaySentence();
        PlayAudio();
    }

    public void EndDialogue()
    {
        Debug.Log("Ende der Konversation");
        conversationTitle.text = "";
        conversationText.text = "";
        //dialogCanvas.gameObject.SetActive(false);
        Debug.Log("Set Canvas.isOpen = false");
        animator.SetBool("IsOpen", false);
        Debug.Log("Invoking AfterDialogFinishedEvent");
        _currentDialogue.AfterDialogFinishedEvent?.Invoke();
    }
}

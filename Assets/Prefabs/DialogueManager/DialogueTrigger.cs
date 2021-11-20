using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Button prevButton;
    public bool fireOnSceneLoad;

    public void TriggerDialogue()
    {
        DialogueManager.GetInstance().StartDialogue(dialogue, prevButton);
    }

    // called first
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }    
    
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        
        if(fireOnSceneLoad) TriggerDialogue();
    }
    
}

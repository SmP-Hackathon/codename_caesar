using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DialogueManager;

    public void TriggerDialogue()
    {
        DialogueManager.StartDialogue(dialogue);
    }
    
}

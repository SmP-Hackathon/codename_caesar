using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea()]
    public string[] sentences;

    public AudioClip[] voices;

    public UnityEvent AfterDialogFinishedEvent;

}

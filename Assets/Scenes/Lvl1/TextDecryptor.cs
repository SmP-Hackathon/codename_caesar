using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TextDecryptor : MonoBehaviour
{
    public TMP_InputField input;
    public TextEncryptor encryptor;
    public UnityEvent decryptedCorrectly;

    public string inputText;

    // Start is called before the first frame update
    void Start()
    {
        if (decryptedCorrectly == null)
        {
            decryptedCorrectly = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputText = input.text;
        if (inputText.ToLower() == encryptor.ClearMessage.ToLower())
        {
            decryptedCorrectly?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RightAnswerChecker : MonoBehaviour
{

    public VigenereEncryptor encryptor;
    public TMPro.TMP_Text text2;
    public UnityEvent RightAnswerEvent;
    public UnityEvent WrongAnswerEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void check()
    {
        
        var _encryptedMessage = Regex.Replace(encryptor.EncryptedMessage.ToLower(), @"[^a-z]+", String.Empty);
        var _typedMessage = Regex.Replace(text2.text.ToLower(), @"[^a-z]+", String.Empty);
        
        Debug.Log("Correct Text:\t\t" + _encryptedMessage);
        Debug.Log("Input Text:\t\t" + _typedMessage);
        //Debug.Log("Correct Text:\t\t" + _encryptedMessage.Length);
        //Debug.Log("Input Text:\t\t" + _typedMessage.Length);
        //Debug.Log(_encryptedMessage.Equals(_typedMessage.ToLower()));
        if (_encryptedMessage == _typedMessage)
        {
            RightAnswerEvent?.Invoke();
            Debug.Log("Answer is right");
        }
        else WrongAnswerEvent?.Invoke();
    }
}

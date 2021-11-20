using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VignereDecryptor : MonoBehaviour
{

    public CipherScheibe scheibe1;
    public CipherScheibe scheibe2;
    public CipherScheibe scheibe3;
    public VigenereEncryptor encryptor;
    public UnityEvent OnLevelSolved;
    public UnityEvent OnWrongEncryptionCheck;
    public string DecryptedMessage {get; private set;}

    public Text DecryptedTextBox;

    private int[] DecryptionKeys = new int[3];
    private char[] alphabet = new char[26]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecryptMessage()
    {
        DecryptionKeys[0] = scheibe1.CurrentCipherKeyNumber;
        DecryptionKeys[1] = scheibe2.CurrentCipherKeyNumber;
        DecryptionKeys[2] = scheibe3.CurrentCipherKeyNumber;
        DecryptedMessage = "";

        int currentIndex = 0;

        foreach (var letter in encryptor.EncryptedMessage.ToLower())
        {
            if(letter == ' ') DecryptedMessage += ' ';
            else
            {
                DecryptedMessage += alphabet[(GetLetterIndexInAlphabet(letter) + DecryptionKeys[currentIndex]) % 26];
                currentIndex++;
                currentIndex = currentIndex % DecryptionKeys.Length;
            }
        }

        DecryptedTextBox.text = DecryptedMessage.ToUpper();

    }

    public void CheckIfMessageEncrypted()
    {
        if(encryptor.ClearMessage.ToLower() == DecryptedMessage.ToLower()) OnLevelSolved?.Invoke();
        else OnWrongEncryptionCheck?.Invoke();
    }

    private int GetLetterIndexInAlphabet(char c)
    {
        int _index = -1;

        for (int i = 0; i < alphabet.Length; i++)
        {
            if (c == alphabet[i])
            {
                _index = i;
            }
        }

        if(_index == -1) throw new ArgumentException($"Invalid Character {c}. Not contained in standard alphabet.");
        return _index;
    }
}

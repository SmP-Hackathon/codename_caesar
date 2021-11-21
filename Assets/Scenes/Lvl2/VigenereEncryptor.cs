using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigenereEncryptor : MonoBehaviour
{

    [TextArea(1,3)]
    public string[] messages;
    public Text EncryptedTextBox;
    public string EncryptionWord;

    public string ClearMessage {get; private set;}
    public string EncryptedMessage {get; private set;}


    private int[] encryptionKeys;
    private char[] alphabet = new char[26]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    // Start is called before the first frame update
    void Start()
    {
        EncryptMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EncryptMessage()
    {   
        EncryptionWord = EncryptionWord.ToLower();

        //Translate Encryption Word to Encryption Keys
        encryptionKeys = new int[EncryptionWord.Length];
        for (int i = 0; i < EncryptionWord.Length; i++)
        {
            var IndexOfCurLetter = GetLetterIndexInAlphabet(EncryptionWord[i]);
            encryptionKeys[i] = IndexOfCurLetter;
            Debug.Log($"Key {i} for letter {EncryptionWord[i]} of the encryption Word is {IndexOfCurLetter}");
            
        }

        //Get random clearMessage to encrypt
        ClearMessage = messages[new System.Random().Next(0,messages.Length-1)].ToLower();
        EncryptedMessage = VigenereEncrypt().ToUpper();

        if(EncryptedTextBox != null)EncryptedTextBox.text = EncryptedMessage;

    }

    private string VigenereEncrypt()
    {
        string _encryptedMessage = "";   
        int currentIndex = 0;

        foreach (var letter in ClearMessage)
        {
            if(letter == ' ') {_encryptedMessage += ' ';}
            else if(letter == '!'){_encryptedMessage += '!';}
            else if(letter == '.'){_encryptedMessage += '.';}
            else
            {
                _encryptedMessage += alphabet[(GetLetterIndexInAlphabet(letter) + encryptionKeys[currentIndex % encryptionKeys.Length]) % 26];
                Debug.Log($"Original Letter:{letter}\t Current Index:{currentIndex}\t Current Shift Index:{encryptionKeys[currentIndex % encryptionKeys.Length]} \tReplaced by:{alphabet[(GetLetterIndexInAlphabet(letter) + encryptionKeys[currentIndex % encryptionKeys.Length]) % 26]}");
                currentIndex++;
            }
        }     
        return _encryptedMessage;
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

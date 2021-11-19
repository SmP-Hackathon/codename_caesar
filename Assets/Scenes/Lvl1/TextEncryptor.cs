using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEncryptor : MonoBehaviour
{

    [TextArea(2,4)]
    public string[] messages;

    public Text encryptedTextBox;

    public void EncryptString()
    {
        var clearMessage = messages[(int)(Random.Range(0f, (float)messages.Length))].ToLower();
        encryptedTextBox.text = CaesarCipher(clearMessage, (int)Random.Range(1f, 25f));

    }

    private string CaesarCipher(string clearMessage, int key)
    {
        char[] alphabet = new char[26]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        string encryptedMessage = "";
        foreach (var currentLetter in clearMessage)
        {
            // Bei Leerzeichen im Klartext einfach ein Leerzeichen in den Ciphertext hinzufügen
            if(currentLetter == ' ') encryptedMessage += ' ';
            else
            {
                int currentLetterIndex = -1;
                
                //Index des Buchstabens herausfinden
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (currentLetter == alphabet[i]) {currentLetterIndex = i; break;}
                }

                // Falls Buchstabe nicht gefunden wurde, Exception werfen
                if (currentLetterIndex == -1) throw new System.Exception("Ungültiges Zeichen im String enthalten. Nur A-Z sind erlaubt.");
                encryptedMessage += alphabet[(currentLetterIndex + key) % 26];
            }
        }

        return encryptedMessage.ToUpper();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

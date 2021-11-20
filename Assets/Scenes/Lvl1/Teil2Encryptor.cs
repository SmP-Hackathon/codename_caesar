using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Teil2Encryptor : MonoBehaviour
{
    public TMP_InputField inputField;
    public UnityEvent encryptedCorrectly;
    public Text clearMessageBox;
    public int key;

    private string inputText;
    private string clearMessage;
    private string encryptedMessage;

    public void checkEncryptedMessage()
    {
        inputText = inputField.text.ToLower();

        // compute encrypted text from clearMessage
        clearMessage = clearMessageBox.text;
        encryptedMessage = CaesarCipher(clearMessage, key).ToLower();
        Debug.Log(encryptedCorrectly);
        Debug.Log(inputText);
        
        if (inputText.ToLower() == encryptedMessage)
        {
            Debug.Log("Richtig");
            encryptedCorrectly?.Invoke();
        }
    }

    private string CaesarCipher(string clearMessage, int key)
    {
        char[] alphabetLower = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] alphabetUpper = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        string encryptedMessage = "";
        foreach (var currentLetter in clearMessage)
        {
            // Bei Leerzeichen im Klartext einfach ein Leerzeichen in den Ciphertext hinzufügen
            if (currentLetter == ' ') encryptedMessage += ' ';
            else if (currentLetter == ',') encryptedMessage += ',';
            else if (currentLetter == '.') encryptedMessage += '.';
            else if (currentLetter == '!') encryptedMessage += '!';
            else if (currentLetter == '?') encryptedMessage += '?';
            else
            {
                int currentLetterIndex = -1;
                bool isUpper = false;

                //Index des Buchstabens herausfinden
                for (int i = 0; i < alphabetLower.Length; i++)
                {
                    if (currentLetter == alphabetLower[i]) { currentLetterIndex = i; isUpper = false; break; }
                    if (currentLetter == alphabetUpper[i]) { currentLetterIndex = i; isUpper = true; break; }
                }

                // Falls Buchstabe nicht gefunden wurde, Exception werfen
                if (currentLetterIndex == -1) throw new System.Exception("Ungültiges Zeichen im String enthalten. Nur A-Z sind erlaubt.");
                if (isUpper)
                {
                    encryptedMessage += alphabetUpper[(currentLetterIndex + key) % 26];
                }
                else
                {
                    encryptedMessage += alphabetLower[(currentLetterIndex + key) % 26];
                }

            }
        }

        return encryptedMessage;
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

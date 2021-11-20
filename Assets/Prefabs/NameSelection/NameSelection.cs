using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameSelection : MonoBehaviour
{
    public string nextScene;
    public UnityEngine.UI.InputField textInput;
    public void onBtnConfirmClick() {
        string userName = textInput.text;
        if (userName == "") return;
        
        PlayerPrefs.SetString("userName", userName);
        SceneManager.LoadScene(nextScene);
    }
}

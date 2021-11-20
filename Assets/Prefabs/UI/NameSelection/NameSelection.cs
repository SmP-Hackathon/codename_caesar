using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSelection : MonoBehaviour
{
    public UnityEngine.UI.InputField textInput;
    public SceneLoader sceneLoader;
    public void OnBtnConfirmClick() {
        string userName = textInput.text;

        if (userName == "") return;

        PlayerPrefs.SetString("userName", userName);

        sceneLoader.LoadScene();        
    }
}

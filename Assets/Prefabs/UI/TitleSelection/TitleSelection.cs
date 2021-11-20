using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelection : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public SceneLoader sceneLoader;
    public void OnBtnConfirmClick() {
        string userTitle = "Agentin";
        foreach (Toggle activeToggle in toggleGroup.ActiveToggles()) {
            userTitle = activeToggle.GetComponentInChildren<Text>().text;
        }

        PlayerPrefs.SetString("userTitle", userTitle);
        Debug.Log(userTitle);

        sceneLoader.LoadScene();
    }
}

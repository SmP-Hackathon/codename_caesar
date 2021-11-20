using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMainMenu : MonoBehaviour
{
    public void onBtnMainMenuClick() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}


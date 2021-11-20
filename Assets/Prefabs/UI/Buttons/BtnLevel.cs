using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnLevel : MonoBehaviour
{
    public string levelName;

    public void onBtnLevelClick() {
        SceneManager.LoadScene(levelName);
    }
}

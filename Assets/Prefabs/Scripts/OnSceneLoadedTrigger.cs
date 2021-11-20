using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnSceneLoadedTrigger : MonoBehaviour
{   
    public UnityEvent ActionToCall;
    
    // called first
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }    
    
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log("Calling action to call");
        ActionToCall?.Invoke();
        //Debug.Log(mode);
        
    }  
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class CipherScheibe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
 {

    public Transform Wheel; //the thing you're trying to rotate
    public Text CipherKey;

    public UnityEvent OnCipherKeyChanged;

    public int CurrentCipherKeyNumber {get; private set;}
    public char CurrentCipherKeyLetter => alphabet[CurrentCipherKeyNumber];

    private char[] alphabet = new char[26]{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    Vector2 dir;
    float dist;
    float check;
    float angle;
    bool checkPoint;
    

    public void Start()
    {
        UpdateLabel();
        OnCipherKeyChanged?.Invoke();
    }

     void Update(){
         //is rotating is set true if mouse is down on the handle
        
     }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("End Dragging");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging begin");
       
    }

    public void OnDrag(PointerEventData eventData)
    {
             //Vector from center to mouse pos
             dir  =    (Input.mousePosition - Wheel.position); 
             //Distance between mouse and the center
             dist =    Mathf.Sqrt (dir.x * dir.x + dir.y * dir.y); 
             //if mouse is not outside nor too inside the wheel
             
                 angle =    Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; //alien technology
                 angle =    (angle > 0) ? angle : angle + 360; //0 to 360 instead of -180 to 180

            Wheel.rotation = Quaternion.Euler(0,0, -angle);
            Debug.Log(Wheel.rotation.eulerAngles.ToString());

            CurrentCipherKeyNumber = (int)((26 - (Mathf.Round(((774.9f - Wheel.rotation.eulerAngles.z) % 360)/13.8461f) % 26)) % 26);

            UpdateLabel();
            OnCipherKeyChanged?.Invoke();
    }

    private void UpdateLabel()
    {
        CipherKey.text = CurrentCipherKeyNumber.ToString() + "/" + CurrentCipherKeyLetter;
    }
}
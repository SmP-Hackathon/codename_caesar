using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CipherScheibe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
 {

    public Transform Wheel; //the thing you're trying to rotate
    public Text CipherKey;
    Vector2 dir;
    float dist;
    float check;
    float angle;
    bool checkPoint;
    

    public void Start()
    {
        UpdateLabel();
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

            

            UpdateLabel();
    }

    private void UpdateLabel()
    {
        CipherKey.text = ((26 - (Mathf.Round(((774.9f - Wheel.rotation.eulerAngles.z) % 360)/13.8461f) % 26)) % 26).ToString();
    }
}
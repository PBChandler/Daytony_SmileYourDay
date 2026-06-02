using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class DragWindow : MonoBehaviour
{
    Vector3 clickPosition;
    Vector2 clickOffset;
    public Transform importantObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }//
    public void OnClick(BaseEventData bed)
    {  
        PointerEventData poc = (PointerEventData)bed;
        clickPosition = poc.pressPosition;
        clickOffset = poc.pressPosition-(Vector2)transform.position;
    }
    public void Drag(BaseEventData bed)
    {
      
   
        PointerEventData poc = (PointerEventData)bed;
        
        importantObject.position = poc.position - clickOffset;
    }
}

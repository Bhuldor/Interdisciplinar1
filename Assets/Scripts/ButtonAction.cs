using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    [HideInInspector]
    protected bool pressed;

    public void OnPointerDown(PointerEventData eventData){
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        pressed = false;
    }

    public bool action(){
        return pressed;
    }
}

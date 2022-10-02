using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputControllerMobile : InputController, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData) => onStartChoiceForce?.Invoke();

    public void OnPointerUp(PointerEventData eventData) => onStopChoiceForce?.Invoke();
}

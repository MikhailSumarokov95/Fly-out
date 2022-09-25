using System;
using System.Collections.Generic;
using UnityEngine;

public class InputControlerPC : InputControler
{
    [SerializeField] KeyCode KeyChoiceForce = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(KeyChoiceForce)) onStartChoiceForce?.Invoke();
        else if (Input.GetKeyUp(KeyChoiceForce)) onStopChoiceForce?.Invoke();
    }
}

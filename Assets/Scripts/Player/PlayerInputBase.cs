using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInputBase : MonoBehaviour
{
    protected PlayerInput NewInput;

    private void Awake()
    {
        NewInput = new PlayerInput();
    }

    private void OnEnable()
    {
        NewInput.Enable();
    }

    private void OnDisable()
    {
        NewInput.Disable();
    }
}

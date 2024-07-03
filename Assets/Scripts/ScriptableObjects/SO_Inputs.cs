using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SO_Inputs", menuName = "ScriptableObjects/Input Manager")]
public class SO_Inputs : ScriptableObject
{
    private IA_Controllers controls;

    public event Action OnInteract;

    private void OnEnable()
    {
        controls = new IA_Controllers();

        SetupGameplay();
    }

    private void SetupGameplay()
    {
        controls.Game.Enable();

        controls.Game.Interact.performed += Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
    }
}

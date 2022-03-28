using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Teaser : MonoBehaviour
{
    [SerializeField] private InputActionReference enter;
    [SerializeField] private GameObject fader;

    private void OnEnable()
    {
        enter.action.Enable();
        enter.action.started += GoToCredits;
    }
    private void OnDisable()
    {
        enter.action.Disable();
        enter.action.started -= GoToCredits;
    }

    private void GoToCredits(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            fader.SetActive(true);
        }
    }
}
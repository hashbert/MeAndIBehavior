using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private InputActionReference pause;
    [SerializeField] private InputActionReference back;
    [SerializeField] private Animator anim;

    private void OnEnable() 
    {
        pause.action.Enable();
        pause.action.performed += PauseCredits;
        back.action.Enable();
        back.action.started += BackToMainMenu;
    }
    private void OnDisable() 
    {
        pause.action.Disable();
        pause.action.performed -= PauseCredits;
        back.action.Disable();
        back.action.started -= BackToMainMenu;
    }

    private void PauseCredits(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (anim.GetFloat("speed")!=0) 
            {
                anim.SetFloat("speed", 0);
            }
            else
            {
                anim.SetFloat("speed", 1);
            }
        }
    }

    private void BackToMainMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
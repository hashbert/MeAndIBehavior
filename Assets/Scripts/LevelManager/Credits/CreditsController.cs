using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private InputActionReference pause;
    [SerializeField] private InputActionReference menu;
    [SerializeField] private InputActionReference restart;
    [SerializeField] private Animator anim;

    private void OnEnable() 
    {
        pause.action.Enable();
        pause.action.performed += PauseCredits;
        menu.action.Enable();
        menu.action.started += BackToMainMenu;
        restart.action.Enable();
        restart.action.started += Restart;
    }
    private void OnDisable() 
    {
        pause.action.Disable();
        pause.action.performed -= PauseCredits;
        menu.action.Disable();
        menu.action.started -= BackToMainMenu;
        restart.action.Disable();
        restart.action.started -= Restart;
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

    private void Restart(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
}
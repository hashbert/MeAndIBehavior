using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuButtons : MonoBehaviour
{
    
    public void PlayButton()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("KeybindUI");
    }
    public void QuitGame()
    {
        if (Application.isPlaying)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}

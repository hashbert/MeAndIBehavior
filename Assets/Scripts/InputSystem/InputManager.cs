using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class InputManager : MonoBehaviour
{
    //static player input class for all to access
    public static PlayerInput playerInput;

    //saving level Number to player prefs
    private int levelNumber;
    //getting Scene name for restarting
    private string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        playerInput = GetComponent<PlayerInput>();
        levelNumber = Int32.Parse(sceneName.Substring(sceneName.Length - 2, 2));
        var highestLevel = PlayerPrefs.GetInt("Level");
        levelNumber = levelNumber < highestLevel ? levelNumber = highestLevel : levelNumber;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level", levelNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRestartInput(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(sceneName);
    }
}

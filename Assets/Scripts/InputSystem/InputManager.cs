using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static PlayerInput playerInput;
    [SerializeField] private int levelNumber;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
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
        SceneManager.LoadScene("Level1");
    }
}

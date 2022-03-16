using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadNorthPanel : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference switchCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpIsGamepadNorth()
    {
        jump.action.ApplyBindingOverride(new InputBinding
        {
            groups = "Gamepad",
            overridePath = "<Gamepad>/buttonNorth"
        });
    }
    public void JumpIsGamepadSouth()
    {
        jump.action.ApplyBindingOverride(new InputBinding
        {
            groups = "Gamepad",
            overridePath = "<Gamepad>/buttonSouth"
        });
    }
    public void JumpIsGamepadWest()
    {
        jump.action.ApplyBindingOverride(new InputBinding
        {
            groups = "Gamepad",
            overridePath = "<Gamepad>/buttonWest"
        });
    }
    public void JumpIsGamepadEast()
    {
        jump.action.ApplyBindingOverride(new InputBinding
        {
            groups = "Gamepad",
            overridePath = "<Gamepad>/buttonEast"
        });
    }
}

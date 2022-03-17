using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AssignAllButtons : MonoBehaviour
{
    private readonly InputAction _anyKeyWait = new InputAction(binding: "/*/<button>", type: InputActionType.Button);
    private void Awake() => _anyKeyWait.performed += DoSomething;
    private void OnEnable() => _anyKeyWait.Enable();
    private void OnDisable() => _anyKeyWait.Disable();
    private void OnDestroy() => _anyKeyWait.performed -= DoSomething;
    private void DoSomething(InputAction.CallbackContext ctx) => AnyKey();
    private void AnyKey()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCameraBackground : MonoBehaviour
{
    private Color initialColor;
    private Color invertedColor;
    private Camera mainCamera;
    [SerializeField] private InputActionReference switchCharacterAction;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        initialColor = mainCamera.backgroundColor;
        invertedColor = new Color(1f - initialColor.r, 1f - initialColor.g, 1f - initialColor.b);
    }

    private void OnEnable()
    {
        switchCharacterAction.action.started += SwapColor;
    }

    private void SwapColor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (mainCamera.backgroundColor == initialColor)
            {
                mainCamera.backgroundColor = invertedColor;
            }
            else
            {
                mainCamera.backgroundColor = initialColor;
            }
        }
    }

    private void OnDisable()
    {
        switchCharacterAction.action.started -= SwapColor;
    }
}

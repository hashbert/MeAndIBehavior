using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCameraBackground : MonoBehaviour
{
    private Color initialColor;
    private Color invertedColor;
    private Camera mainCamera;
    private bool _startingColor = true;
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
            //if (mainCamera.backgroundColor == initialColor)
            //{
            //    mainCamera.backgroundColor = invertedColor;
            //}
            //else
            //{
            //    mainCamera.backgroundColor = initialColor;
            //}
            if (_startingColor)
            {
                _startingColor = false;
                mainCamera.gameObject.LeanColor(Color.black, 0.5f).setEase(LeanTweenType.easeOutQuint);
            }
            else
            {
                _startingColor = true;
                mainCamera.gameObject.LeanColor(Color.white, 0.5f).setEase(LeanTweenType.easeOutQuint);
            }
            
            
        }
    }

    private void OnDisable()
    {
        switchCharacterAction.action.started -= SwapColor;
    }
}

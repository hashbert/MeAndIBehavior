using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InvertColorImage : MonoBehaviour
{
    [SerializeField] private Color initialColor;
    [SerializeField] private Color invertedColor;
    [SerializeField] private Image image;
    [SerializeField] private SwitchCharacter switchCharacter;
    [SerializeField] private InputActionReference switchCharacterAction;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        initialColor = image.color;
        invertedColor = new Color(1f - initialColor.r, 1f - initialColor.g, 1f - initialColor.b);
        switchCharacter = GameObject.Find("Managers").transform.Find("SwitchCharacter").GetComponent<SwitchCharacter>();
    }

    private void OnEnable()
    {
        switchCharacterAction.action.started += SwapColor;
    }
    private void OnDisable()
    {
        switchCharacterAction.action.started -= SwapColor;
    }
    private void SwapColor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (switchCharacter.KidActive)
            {
                image.color = initialColor;
            }
            else
            {
                image.color = invertedColor;
            }
        }
    }


}

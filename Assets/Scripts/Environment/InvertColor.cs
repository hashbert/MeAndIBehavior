using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertColor : MonoBehaviour
{
    [SerializeField] private Color initialColor;
    [SerializeField] private Color invertedColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SwitchCharacter switchCharacter;
    [SerializeField] private InputActionReference switchCharacterAction;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        invertedColor = new Color(1f - initialColor.r, 1f - initialColor.g, 1f - initialColor.b);
        switchCharacter = GameObject.Find("Managers").transform.Find("SwitchCharacter").GetComponent<SwitchCharacter>();
    }

    private void OnEnable()
    {
        switchCharacterAction.action.started += SwapColor;
    }

    private void SwapColor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (switchCharacter.KidActive)
            {
                spriteRenderer.color = initialColor;
            }
            else
            {
                spriteRenderer.color = invertedColor;
            }
        }
    }

    private void OnDisable()
    {
        switchCharacterAction.action.started -= SwapColor;
    }
}

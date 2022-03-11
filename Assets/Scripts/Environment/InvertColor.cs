using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertColor : MonoBehaviour
{
    private Color initialColor;
    private Color invertedColor;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private InputActionReference switchCharacterAction;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
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
            if (spriteRenderer.color == initialColor)
            {
                spriteRenderer.color = invertedColor;
            }
            else
            {
                spriteRenderer.color = initialColor;
            }
        }
    }

    private void OnDisable()
    {
        switchCharacterAction.action.started -= SwapColor;
    }
}

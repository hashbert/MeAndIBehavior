using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color initialColor;
    private Color invertedColor;

    //[SerializeField] private InputAction SwitchCharacterAction;
    //[SerializeField] private PlayerInput playerInput;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        Debug.Log(initialColor + "initial color");
        invertedColor = new Color(1f - initialColor.r, 1f - initialColor.g, 1f - initialColor.b);
        Debug.Log(invertedColor + "inverted color");
        //SwitchCharacterAction.performed += context => SwapColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwapColor()
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

    public void OnInvertColorInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Q hit!");
            SwapColor();
        }
    }

    //private void OnEnable()
    //{
    //    SwitchCharacterAction.Enable();
    //}
    //private void OnDisable()
    //{
    //    SwitchCharacterAction.Disable();
    //}
}

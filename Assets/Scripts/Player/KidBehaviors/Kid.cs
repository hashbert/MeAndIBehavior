using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kid : MonoBehaviour
{
    #region Start() variables
    public Rigidbody2D PlayerRb { get; private set; }
    public Collider2D PlayerColl { get; private set; }
    #endregion

    #region Other Variables
    
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float slowdownFraction = .5f;
    [SerializeField] private float floatFallSpeed = 1f;
    [SerializeField] private bool isFacingLeft = true;
    public bool SpaceHeld { get; private set; }

    private float boxExtensionHeight = 0.1f; //used for ground check

    #endregion

    #region Unity Callback Functions

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerColl = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Color color = Color.red;
        Debug.DrawRay(PlayerColl.bounds.center, Vector2.down * (PlayerColl.bounds.extents.y + boxExtensionHeight), color);
        Move();
        Float();
    }

    #endregion

    #region Player Input Abilities
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<float>());
        if (context.started && IsGrounded())
        {
            PlayerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (context.canceled && PlayerRb.velocity.y > 0f)
        {
            PlayerRb.AddForce(new Vector2(0f, -PlayerRb.velocity.y * slowdownFraction), ForceMode2D.Impulse);
        }
    }
    public void OnFloatInput(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump pressed");
        if (context.started)
        {
            SpaceHeld = true;
        }
        if (context.canceled)
        {
            SpaceHeld = false;
        }
    }
    #endregion

    #region Check Functions
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(PlayerColl.bounds.center, PlayerColl.bounds.size, 0f, Vector2.down, boxExtensionHeight, groundLayerMask);
        return raycastHit.collider != null;
    }

    private void CheckIfShouldFlip()
    {
        if (isFacingLeft && horizontalInput > 0f)
        {
            Flip();
        }
        else if (!isFacingLeft && horizontalInput < 0f)
        {
            Flip();
        }
    }
    #endregion

    #region Other Functions
    private void Move()
    {
        PlayerRb.velocity = new Vector2(horizontalInput * speed, PlayerRb.velocity.y);
        CheckIfShouldFlip();
    }

    private void Float()
    {
        if (SpaceHeld && !IsGrounded() && PlayerRb.velocity.y < 0.1f)
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, -floatFallSpeed);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    #endregion
}

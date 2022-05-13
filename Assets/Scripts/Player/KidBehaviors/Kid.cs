using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using System;

public class Kid : MonoBehaviour
{
    #region Start() variables
    public Rigidbody2D KidRb { get; private set; }
    public GameObject AdultRb { get; private set; }
    public Collider2D PlayerColl { get; private set; }
    public Animator KidAnim { get; private set; }

    private ParticleSystem teleportParticle; 
    #endregion

    #region Other Variables

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask groundOnlyLayerMask;
    [SerializeField] private float horizontalInput; //value between -1 and 1 inclusive
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private float slowdownFraction = .5f;
    [SerializeField] private float floatFallSpeed = 1f;
    [SerializeField] private bool isFacingLeft = true;
    [SerializeField] private InputActionReference jump;
    public bool SpaceHeld { get; private set; }

    private float boxExtensionHeight = 0.1f; //used for ground check
    private Vector2 kidPosition;
    [SerializeField] private float teleportHeight;
    #endregion

    //actions
    public static event Action OnTeleportNotAllowed;

    #region Unity Callback Functions

    private void Start()
    {
        KidRb = GetComponent<Rigidbody2D>();
        PlayerColl = GetComponent<BoxCollider2D>();
        AdultRb = GameObject.Find("Adult");
        KidAnim = GetComponent<Animator>();
        teleportParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        Color color = Color.red;
        Debug.DrawRay(PlayerColl.bounds.center, Vector2.down * (PlayerColl.bounds.extents.y + boxExtensionHeight), color);
        Move();
        Float();
        kidPosition = transform.position;
    }
    private void OnEnable()
    {
        jump.action.started += OnJumpInput;
        jump.action.canceled += OnJumpInput;
    }

    private void OnDisable()
    {
        jump.action.started -= OnJumpInput;
        jump.action.canceled -= OnJumpInput;
    }
    #endregion

    #region Player Input Abilities
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
    private void OnJumpInput(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<float>());
        if (context.started && IsGrounded())
        {
            KidRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            RuntimeManager.PlayOneShotAttached("event:/SFX/Young/Jump", gameObject);
        }
        if (context.canceled && KidRb.velocity.y > 0f)
        {
            KidRb.AddForce(new Vector2(0f, -KidRb.velocity.y * slowdownFraction), ForceMode2D.Impulse);
        }
        if (context.started)
        {
            SpaceHeld = true;
        }
        if (context.canceled)
        {
            SpaceHeld = false;
        }
    }

    public void OnTeleportInput(InputAction.CallbackContext context)
    {
        if (context.started && KidAnim.GetInteger("KidState") == 0 && KidAnim.enabled && !IsOnGround())
        {
            OnTeleportNotAllowed?.Invoke();
        }
        if (context.started && KidAnim.GetInteger("KidState")==0 && KidAnim.enabled && IsOnGround())
        {
            teleportParticle.Play();
            KidAnim.SetInteger("KidState", 5);
            RuntimeManager.PlayOneShotAttached("event:/SFX/Young/Teleport", gameObject);
        }
    }

    private void TeleportAdult()
    {
        AdultRb.transform.position = kidPosition + new Vector2(0, teleportHeight);
        KidAnim.SetInteger("KidState", 0);
    }
    #endregion

    #region Check Functions
    public bool IsGrounded()  //can jump off of boxes and ground
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(PlayerColl.bounds.center - new Vector3(0, PlayerColl.bounds.extents.y, 0), 
            new Vector2(PlayerColl.bounds.size.x, boxExtensionHeight), 0f, Vector2.down, boxExtensionHeight / 2, groundLayerMask);
        return raycastHit.collider != null;
    }
    public bool IsOnGround() //can switch to adult or teleport when on ground only
    {
        //RaycastHit2D otherRaycastHit = Physics2D.BoxCast(PlayerColl.bounds.center, PlayerColl.bounds.size, 0f, Vector2.down, boxExtensionHeight, groundOnlyLayerMask);
        RaycastHit2D otherRaycastHit = Physics2D.BoxCast(PlayerColl.bounds.center - new Vector3(0, PlayerColl.bounds.extents.y, 0), 
            new Vector2(PlayerColl.bounds.size.x, boxExtensionHeight), 0f, Vector2.down, boxExtensionHeight/2, groundOnlyLayerMask);
        return otherRaycastHit.collider != null;
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
        if (SpaceHeld) //when jumping, move normally
        {
            KidRb.velocity = new Vector2(horizontalInput * speed, KidRb.velocity.y);
        }
        else if(KidRb.velocity.y>0.1f) //when going up a slope, slow max speed up ramp
        {
            var moveVector = new Vector2(horizontalInput * speed, KidRb.velocity.y);
            KidRb.velocity = Vector2.ClampMagnitude(moveVector, speed);
        }
        else //move normally
        {
            KidRb.velocity = new Vector2(horizontalInput * speed, KidRb.velocity.y);
        }
            CheckIfShouldFlip();
    }

    private void Float()
    {
        if (SpaceHeld && !IsGrounded() && KidRb.velocity.y < 0.1f)
        {
            KidRb.velocity = new Vector2(KidRb.velocity.x, -floatFallSpeed);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    #endregion
}

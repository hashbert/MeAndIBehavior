using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Adult : MonoBehaviour
{
    #region Awake() variables
    public Rigidbody2D PlayerRb { get; private set; }
    public Collider2D PlayerColl { get; private set; }
    #endregion

    #region Start() variables
    public Transform Kid { get; private set; }
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private CinemachineBehavior _cinemachineBehavior;
    #endregion
    #region Other Variables

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float slowdownFraction = .5f;
    [SerializeField] private float teleportHeight;

    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference teleport;
    public bool IsFacingRight { get; private set; }
    public bool SpaceHeld { get; private set; }
    //[SerializeField] private InputActionReference grab;

    private float boxExtensionHeight = 0.1f; //raycast for checking if grounded

    #endregion

    //actions
    public static event Action OnTeleportNotAllowed;

    #region Unity Callback Functions

    private void Awake()
    {
        IsFacingRight = true;
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerColl = GetComponent<Collider2D>();
        //grab.action.Disable();
    }

    private void Start()
    {
        Kid = FindObjectOfType<Kid>().transform;
        _cinemachineBehavior = FindObjectOfType<CinemachineBehavior>();
    }
    private void Update()
    {
        Color color = Color.red;
        //Debug.DrawRay(PlayerColl.bounds.center, Vector2.down * (PlayerColl.bounds.extents.y + boxExtensionHeight), color);
        Move();
    }

    private void OnEnable()
    {
        jump.action.started += OnJumpInput;
        jump.action.canceled += OnJumpInput;
        teleport.action.started += OnTeleportInput;
    }

    private void OnDisable()
    {
        jump.action.started -= OnJumpInput;
        jump.action.canceled -= OnJumpInput;
        teleport.action.started -= OnTeleportInput;
    }

    #endregion

    #region Player Input Abilities
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            PlayerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/Old/Jump", gameObject);
        }
        if (context.canceled && PlayerRb.velocity.y > 0f)
        {
            PlayerRb.AddForce(new Vector2(0f, -PlayerRb.velocity.y * slowdownFraction), ForceMode2D.Impulse);
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
        if (context.started)
        {
            //OnTeleportNotAllowed?.Invoke();
            //LeanTween.move(gameObject, Kid.transform.position + new Vector3(0, teleportHeight), 1f);
            StartCoroutine(SmokeAndTeleport());
        }
    }

    private IEnumerator SmokeAndTeleport()
    {
        _smoke.Play();
        yield return new WaitForSeconds(.75f);
        StartCoroutine(_cinemachineBehavior.PlayKidCamera());
        yield return new WaitForSeconds(.75f);
        transform.position = Kid.transform.position + new Vector3(0, teleportHeight);
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
        if (IsFacingRight && horizontalInput < 0f)
        {
            Flip();
        }
        else if (!IsFacingRight && horizontalInput > 0f)
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
            PlayerRb.velocity = new Vector2(horizontalInput * speed, PlayerRb.velocity.y);
        }
        else if (PlayerRb.velocity.y > 0.1f) //when going up a slope, slow max speed up ramp
        {
            var moveVector = new Vector2(horizontalInput * speed, PlayerRb.velocity.y);
            PlayerRb.velocity = Vector2.ClampMagnitude(moveVector, speed);
        }
        else //move normally
        {
            PlayerRb.velocity = new Vector2(horizontalInput * speed, PlayerRb.velocity.y);
        }
        CheckIfShouldFlip();
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    #endregion
}

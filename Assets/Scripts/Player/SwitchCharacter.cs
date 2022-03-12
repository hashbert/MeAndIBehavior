using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCharacter : MonoBehaviour
{
    public bool KidActive { get; private set; }

    //kid
    private GameObject kid;
    private Rigidbody2D kidRb;
    private Kid kidScript;
    private BoxCollider2D kidBoxColl;
    private Animator kidAnim;

    //adult
    private GameObject adult;
    private Rigidbody2D adultRb;
    private Adult adultScript;
    private BoxCollider2D adultBoxColl;
    private Animator adultAnim;

    //camera background
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color initialBackgroundColor;
    [SerializeField] private Color invertedBackgroundColor;

    private void Awake()
    {
        //kid
        kid = GameObject.Find("Kid");
        kidRb = kid.GetComponent<Rigidbody2D>();
        kidScript = kid.GetComponent<Kid>();
        kidBoxColl = kid.GetComponent<BoxCollider2D>();
        kidAnim = kid.GetComponent<Animator>();
        KidActive = true;

        //adult
        adult = GameObject.Find("Adult");
        adultRb = adult.GetComponent<Rigidbody2D>();
        adultScript = adult.GetComponent<Adult>();
        adultBoxColl = adult.GetComponent<BoxCollider2D>();
        adultAnim = adult.GetComponent<Animator>();

        //camera
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        initialBackgroundColor = mainCamera.backgroundColor;
        invertedBackgroundColor = new Color(1f - initialBackgroundColor.r, 1f - initialBackgroundColor.g, 1f - initialBackgroundColor.b);

    }
    // Start is called before the first frame update
    void Start()
    {
        FreezeAdult();
    }

    private void FreezeAdult()
    {
        //freeze adult and allow walk through
        adultRb.bodyType = RigidbodyType2D.Static;
        adultScript.enabled = false;
        adultBoxColl.enabled = false;
        adultAnim.enabled = false;
        InputManager.playerInput.actions["Grab"].Disable();
    }
    private void UnfreezeAdult()
    {
        //unfreeze adult and allow walk through
        adultRb.bodyType = RigidbodyType2D.Dynamic;
        adultScript.enabled = true;
        adultBoxColl.enabled = true;
        adultAnim.enabled = true;
        InputManager.playerInput.actions["Grab"].Enable();
    }
    private void FreezeKid()
    {
        //freeze kid and allow walk through
        kidRb.bodyType = RigidbodyType2D.Static;
        kidScript.enabled = false;
        kidBoxColl.enabled = false;
        kidAnim.enabled = false;
    }
    private void UnfreezeKid()
    {
        //unfreeze kid and allow walk through
        kidRb.bodyType = RigidbodyType2D.Dynamic;
        kidScript.enabled = true;
        kidBoxColl.enabled = true;
        kidAnim.enabled = true;
    }


    private void SwapColor()
    {
        if (mainCamera.backgroundColor == initialBackgroundColor)
        {
            mainCamera.backgroundColor = invertedBackgroundColor;
            Debug.Log("change to inverted background color");
        }
        else
        {
            mainCamera.backgroundColor = initialBackgroundColor;
            Debug.Log("change to initial background color");
        }
    }

    public void OnSwitchCharacter(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (KidActive && kidAnim.GetInteger("KidState") == 0 && kidScript.IsOnGround())
            {
                FreezeKid();
                UnfreezeAdult();
                SwapColor();
                KidActive = !KidActive;
            }
            else if (!KidActive)
            {
                UnfreezeKid();
                FreezeAdult();
                SwapColor();
                KidActive = !KidActive;
            }
        }
    }
}

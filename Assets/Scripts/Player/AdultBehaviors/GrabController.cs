using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    //Awake() variables
    [SerializeField] private Transform grabDetect;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Animator adultAnim;

    //Grab Detect what layerMask and how far?
    [SerializeField] private LayerMask boxLayerMask;
    [SerializeField] private float rayDist;

    public bool IsHoldingBox { get; private set; }
    private GameObject boxObject;
    public RaycastHit2D GrabCheck { get; private set; }

    private void Start()
    {
        grabDetect = transform.Find("GrabDetect").transform;
        holdPosition = transform.Find("HoldPosition").transform;
        adultAnim = gameObject.GetComponent<Animator>();
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
            if (IsHoldingBox && adultAnim.GetInteger("AdultState")==8)
            {
                Drop();
                adultAnim.SetInteger("AdultState", 0);
            }
            else if (!IsHoldingBox && GrabCheck.collider != null)
            {
                adultAnim.SetInteger("AdultState", 7);
            }
        }
    }

    public void Grab(RaycastHit2D grabCheck)
    {
        boxObject = grabCheck.collider.gameObject;
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        boxObject.transform.parent = holdPosition;
        boxObject.transform.position = holdPosition.position;
        IsHoldingBox = true;
    }

    private void Drop()
    {
        
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxObject.transform.parent = null;
        IsHoldingBox = false;
    }

    private void PickupStandState()
    {
        adultAnim.SetInteger("AdultState", 8);
    }
}

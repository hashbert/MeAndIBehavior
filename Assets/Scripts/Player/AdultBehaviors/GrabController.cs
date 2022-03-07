using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    //Awake() variables
    [SerializeField] private Transform grabDetect;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Animator animator;

    //Grab Detect what layerMask and how far?
    [SerializeField] private LayerMask boxLayerMask;
    [SerializeField] private float rayDist;

    [SerializeField] private float liftDuration = 0.5f;

    public bool IsHoldingBox { get; private set; }
    private GameObject boxObject;

    private void Start()
    {
        grabDetect = transform.Find("GrabDetect").transform;
        holdPosition = transform.Find("HoldPosition").transform;
        animator = gameObject.GetComponent<Animator>();
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
            if (IsHoldingBox)
            {
                Drop();
            }
            else if (CanGrab(ref grabCheck))
            {
                animator.SetInteger("AdultState", 7);
                StartCoroutine(Grab(liftDuration, grabCheck));
            }
        }
    }

    private bool CanGrab(ref RaycastHit2D grabCheck)
    {
        return !IsHoldingBox && grabCheck.collider != null;
    }

    IEnumerator Grab(float seconds, RaycastHit2D grabCheck)
    {
        yield return new WaitForSeconds(seconds);
        boxObject = grabCheck.collider.gameObject;
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        boxObject.transform.parent = holdPosition;
        boxObject.transform.position = holdPosition.position;
        IsHoldingBox = true;
        animator.SetInteger("AdultState", 8);
    }

    //private void Grab(RaycastHit2D grabCheck)
    //{
        
    //    boxObject = grabCheck.collider.gameObject;
    //    boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    //    boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //    boxObject.transform.parent = holdPosition;
    //    boxObject.transform.position = holdPosition.position;
    //    IsHoldingBox = true;
    //    animator.SetInteger("AdultState", 8);
    //}

    private void Drop()
    {
        
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxObject.transform.parent = null;
        IsHoldingBox = false;
    }

    //public void Pickup(GameObject grabObject)
    //{
    //    IsHoldingBox = true;

    //    grabObject.transform.parent = holdPosition;
    //    grabObject.transform.position = new Vector2(holdPosition.position.x, holdPosition.position.y);
    //    grabObject.GetComponent<Rigidbody2D>().isKinematic = true;

    //    heldBox = grabObject;
    //    //RuntimeManager.PlayOneShotAttached("event:/SFX/Interactables/Crate Pickup", gameObject);
    //}

    //public void Drop()
    //{
    //    if (IsHoldingBox == true)
    //    {
    //        IsHoldingBox = false;
    //        heldBox.GetComponent<Rigidbody2D>().isKinematic = false;
    //        heldBox.transform.parent = null;

    //        heldBox = null;
    //        //RuntimeManager.PlayOneShotAttached("event:/SFX/Interactables/Crate Drop", gameObject);
    //    }
    //}

    //public bool CanGrab(out GameObject grabObject)
    //{
    //    if (IsHoldingBox)
    //    {
    //        grabObject = null;
    //        return false;
    //    }
    //    RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
    //    grabObject = grabCheck.collider?.gameObject;
    //    return grabCheck.collider != null && grabCheck.collider.tag == "Box";
    //}

    //public void OnGrabInput(InputAction.CallbackContext context)
    //{

    //    //RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
    //    if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
    //    {
    //        if (context.started)
    //        {
    //            grabCheck.collider.gameObject.transform.parent = holdPosition;
    //            grabCheck.collider.gameObject.transform.position = holdPosition.position;
    //            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    //        }
    //        else
    //        {
    //            grabCheck.collider.gameObject.transform.parent = null;
    //            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    //        }
    //    }
    //}

}

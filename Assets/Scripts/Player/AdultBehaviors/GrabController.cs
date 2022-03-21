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
    [SerializeField] private GameObject boxCollider;

    public bool IsHoldingBox { get; private set; }
    private GameObject boxObject;
    [SerializeField] private float pickupHeight = 2.05f;

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
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
            if (IsHoldingBox && adultAnim.GetInteger("AdultState")==8)
            {
                Drop();
            }
            else if (!IsHoldingBox && grabCheck.collider != null && adultAnim.GetInteger("AdultState") == 0)
            {
                boxObject = grabCheck.collider.gameObject;
                boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                boxObject.transform.parent = holdPosition;
                boxObject.transform.position = holdPosition.position - new Vector3(0, -pickupHeight, 0);
                adultAnim.SetInteger("AdultState", 7);
            }
        }
    }

    private void Grab()
    {
        boxObject.transform.position = holdPosition.position;
        IsHoldingBox = true;
        boxCollider.SetActive(true);
        adultAnim.SetInteger("AdultState", 8);
    }

    private void Drop()
    {
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxObject.transform.parent = null;
        IsHoldingBox = false;
        boxCollider.SetActive(false);
        adultAnim.SetInteger("AdultState", 0);
    }
}

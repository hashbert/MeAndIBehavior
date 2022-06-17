using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    //Awake() variables
    [SerializeField] private Transform grabDetect;
    [SerializeField] private Transform grabDetect1;
    [SerializeField] private Transform grabDetect2;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Animator adultAnim;

    //Grab Detect what layerMask and how far?
    [SerializeField] private LayerMask boxLayerMask;
    [SerializeField] private float rayDist;
    [SerializeField] private GameObject boxCollider;

    //where to put the box after grabbing
    [SerializeField] private Adult adult;
    public bool IsHoldingBox { get; private set; }
    private GameObject boxObject;
    private float _pickupTime = .5f;

    //[SerializeField] private float pickupHeight = 2.05f;

    private void Start()
    {
        grabDetect = transform.Find("GrabDetect").transform;
        grabDetect1 = transform.Find("GrabDetect1").transform;
        grabDetect2 = transform.Find("GrabDetect2").transform;
        holdPosition = transform.Find("HoldPosition").transform;
        adultAnim = gameObject.GetComponent<Animator>();
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
            RaycastHit2D grabCheck1 = Physics2D.Raycast(grabDetect1.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
            RaycastHit2D grabCheck2 = Physics2D.Raycast(grabDetect2.position, Vector2.right * transform.localScale.x, rayDist, boxLayerMask);
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
                //boxObject.transform.position = holdPosition.position - new Vector3(0, -pickupHeight, 0);
                adultAnim.SetInteger("AdultState", 7);
            }
            else if (!IsHoldingBox && grabCheck1.collider != null && adultAnim.GetInteger("AdultState") == 0)
            {
                boxObject = grabCheck1.collider.gameObject;
                boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                boxObject.transform.parent = holdPosition;
                adultAnim.SetInteger("AdultState", 9);
            }
            else if (!IsHoldingBox && grabCheck2.collider != null && adultAnim.GetInteger("AdultState") == 0)
            {
                boxObject = grabCheck2.collider.gameObject;
                boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                boxObject.transform.parent = holdPosition;
                adultAnim.SetInteger("AdultState", 9);
            }
        }
    }

    private void Grab()
    {
        var right = adult.IsFacingRight ? 1 : -1;
        var xShift = boxObject.GetComponent<Collider2D>().bounds.size.x / 2f;
        var yShift = boxObject.GetComponent<Collider2D>().bounds.size.y / 2f;
        var newPos = holdPosition.position + new Vector3(xShift * right, yShift, 0);
        //LeanTween.move(boxObject.gameObject, newPos, _pickupTime);
        boxObject.transform.position = holdPosition.position + new Vector3(xShift * right, yShift, 0);
        IsHoldingBox = true;
        boxCollider.SetActive(true);
        boxCollider.GetComponent<BoxCollider2D>().size = boxObject.GetComponent<Collider2D>().bounds.size * 2;
        boxCollider.GetComponent<BoxCollider2D>().offset = new Vector2(holdPosition.localPosition.x - xShift * 2, holdPosition.localPosition.y + yShift * 2);
        //LeanTween.moveLocal(boxObject.gameObject, -adult.transform.position + holdPosition.position + new Vector3(xShift * right, yShift, 0), _pickupTime);
    }
    public void GoToPickupStand()
    {
        adultAnim.SetInteger("AdultState", 8);
    }

    public void Drop()
    {
        boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        boxObject.transform.parent = null;
        IsHoldingBox = false;
        boxCollider.SetActive(false);
        adultAnim.SetInteger("AdultState", 0);
        print("box dropped in the GRABCONTROLLER");
    }
}

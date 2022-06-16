using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    //attaches player to a moving platform
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask boxLayerMask;
    [SerializeField] private GrabController grabController;
    private Animator adultAnim;

    private void Start()
    {
        grabController = GameObject.Find("Adult").GetComponent<GrabController>();
        adultAnim = GameObject.FindGameObjectWithTag("Adult").GetComponent<Animator>();
    }
    //float platformExtensionHeight = 0.2f;

    //private void Update()
    //{
    //    BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
    //    Color color = Color.red;
    //    Debug.DrawRay(boxCollider.bounds.center + new Vector3(0, boxCollider.bounds.extents.y, 0), new Vector3(0, platformExtensionHeight, 0), color);
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ground triggered something");
        if ((playerLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(transform);
        }
        if ((boxLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0 && adultAnim.GetInteger("AdultState") != 7)
        {
            if (grabController.IsHoldingBox && collision.gameObject.transform.parent == grabController.gameObject.transform.Find("HoldPosition").transform)
            {
                grabController.Drop();
            }
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((playerLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(null);
        }
        //if ((boxLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        //{
        //    collision.transform.SetParent(null);
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("platform hit something");
    //    BoxCollider2D platformCollider = GetComponent<BoxCollider2D>();
    //    RaycastHit2D boxRaycastHit = Physics2D.BoxCast(platformCollider.bounds.center + new Vector3(0, platformCollider.bounds.extents.y, 0), 
    //        new Vector2(platformCollider.bounds.size.x, platformExtensionHeight), 0f, Vector2.up, platformExtensionHeight / 2, boxLayerMask);

    //    if (boxRaycastHit.collider != null)
    //    {
    //        grabController.Drop();
    //        boxRaycastHit.collider.transform.parent = transform;
    //    }

    //    RaycastHit2D playerRaycastHit = Physics2D.BoxCast(platformCollider.bounds.center + new Vector3(0, platformCollider.bounds.extents.y, 0),
    //        new Vector2(platformCollider.bounds.size.x, platformExtensionHeight), 0f, Vector2.up, platformExtensionHeight / 2, playerLayerMask);
    //    if (playerRaycastHit.collider != null)
    //    {
    //        playerRaycastHit.collider.transform.parent = transform;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("object exited collision");
    //    if ((playerLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
    //    {
    //        collision.transform.SetParent(null);
    //    }
    //}

}

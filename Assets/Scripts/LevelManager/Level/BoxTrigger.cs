using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask canBeParentedToBox;
    [SerializeField] private LayerMask boxLayerMask;
    [SerializeField] private Transform boxParent;
    [SerializeField] private GrabController grabController;

    private void Start()
    {
        grabController = GameObject.Find("Adult").GetComponent<GrabController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((canBeParentedToBox.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(boxParent.transform);
            print("trigger entered!");
        }
        if ((boxLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(boxParent.transform);
            var boxObject = collision.gameObject;
            boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            boxObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            print("trigger entered!");
            if (grabController.IsHoldingBox && collision.transform.parent!=null)
            {
                grabController.Drop();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((canBeParentedToBox.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(null);
            print("trigger exited!");
        }
        if ((boxLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            var boxObject = collision.gameObject;
            boxObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            boxObject.transform.parent = null;
            print("trigger as box exited!");
        }
    }
}

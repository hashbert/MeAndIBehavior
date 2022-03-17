using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    public bool isGrounded = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //checks collision.gameObject.layer and ground are the same
        isGrounded = collision != null && (((1 << collision.gameObject.layer) & ground) != 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}

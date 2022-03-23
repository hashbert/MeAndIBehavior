using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    //private float rayDistance = 0.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Debug.Log("box was hit by ground from any side");
            //RaycastHit2D raycastHit = Physics2D.BoxCast(gameObject.GetComponent<Collider2D>().bounds.center - new Vector3(0, gameObject.GetComponent<Collider2D>().bounds.extents.y, 0),
            //    new Vector2(gameObject.GetComponent<Collider2D>().bounds.size.x, rayDistance), 0f, Vector2.down, rayDistance / 2, groundLayer);
            //if (raycastHit.collider != null)
            //{
            //    Debug.Log("box was hit from bottom");
            //}
        }
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    Debug.Log("box was hit by ground");
        //}
    }
}

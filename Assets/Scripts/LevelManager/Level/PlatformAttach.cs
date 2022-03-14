using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    //attaches player to a moving platform
    [SerializeField] private LayerMask playerLayerMask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerLayerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }
}

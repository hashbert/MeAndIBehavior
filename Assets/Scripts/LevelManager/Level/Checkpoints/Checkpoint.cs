using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform KidPosition;
    [SerializeField] private Transform AdultPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kid") || collision.CompareTag("Adult"))
        {
            CheckpointManager.instance.KidTransform = KidPosition;
            CheckpointManager.instance.AdultTransform = AdultPosition;
        }
    }
}

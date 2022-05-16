using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform AdultSpawnPosition;
    [SerializeField] private Transform KidSpawnPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kid") || collision.CompareTag("Adult"))
        {
            CheckpointManager.instance.checkpointAdultPosition = AdultSpawnPosition.position;
            CheckpointManager.instance.checkpointKidPosition = KidSpawnPosition.position;
        }
    }
}

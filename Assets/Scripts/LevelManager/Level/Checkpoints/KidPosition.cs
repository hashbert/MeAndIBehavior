using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPosition : MonoBehaviour
{
    void Start()
    {
        if (CheckpointManager.instance.checkpointKidPosition != null)
        {
            transform.position = CheckpointManager.instance.checkpointKidPosition;
        }
        else
        {
            transform.position = CheckpointManager.instance.initialKidTransform.position;
        }
    }
}

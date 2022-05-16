using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultPosition : MonoBehaviour
{
    void Start()
    {
        if (CheckpointManager.instance.checkpointAdultPosition != null)
        {
            transform.position = CheckpointManager.instance.checkpointAdultPosition;
        }
        else
        {
            transform.position = CheckpointManager.instance.initialAdultTransform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPosition : MonoBehaviour
{
    void Start()
    {
        transform.position = CheckpointManager.instance.KidTransform.position;
    }
}

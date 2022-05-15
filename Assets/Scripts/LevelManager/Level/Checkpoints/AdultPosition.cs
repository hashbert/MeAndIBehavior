using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultPosition : MonoBehaviour
{
    void Start()
    {
        transform.position = CheckpointManager.instance.AdultTransform.position;
    }
}

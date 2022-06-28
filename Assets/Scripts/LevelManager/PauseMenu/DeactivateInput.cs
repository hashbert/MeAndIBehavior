using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInput : MonoBehaviour
{
    public void DeactivatePlayerInput()
    {
        InputManager.playerInput.DeactivateInput();
    }
}

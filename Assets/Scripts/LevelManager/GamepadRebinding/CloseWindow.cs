using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
    [SerializeField] private Button northToggle;
    public void Close()
    {
        gameObject.SetActive(false);
        northToggle.Select();
    }
}

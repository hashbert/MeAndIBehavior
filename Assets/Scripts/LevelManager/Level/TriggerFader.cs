using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerFader : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        fader.SetActive(true);
    }
}

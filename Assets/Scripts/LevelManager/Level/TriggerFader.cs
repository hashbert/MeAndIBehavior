using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerFader : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    [SerializeField] private Material plainMaterial;
    [SerializeField] private GameObject kidObject;
    [SerializeField] private GameObject adultObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fader.SetActive(true);
        adultObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        kidObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        GetComponent<SpriteRenderer>().material = plainMaterial;
    }
}

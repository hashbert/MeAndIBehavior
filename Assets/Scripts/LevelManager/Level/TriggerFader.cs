using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerFader : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    [SerializeField] private Material plainMaterial;
    [SerializeField] private GameObject kidObject;
    [SerializeField] private GameObject adultObject;
    [SerializeField] private float slowMotionFraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fader.SetActive(true);
        adultObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        kidObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        GetComponent<SpriteRenderer>().material = plainMaterial;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/In Game/Level Complete", gameObject);
        GetComponent<BoxCollider2D>().enabled = false;
        SlowTime();
    }

    private void SlowTime()
    {
        Time.timeScale = slowMotionFraction;
        Time.fixedDeltaTime *= slowMotionFraction;
    }

    private void OnDestroy()
    {
        ResetTime();
    }

    private static void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}

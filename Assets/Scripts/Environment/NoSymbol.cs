using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class NoSymbol : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnEnable()
    {
        SwitchCharacter.OnSwitchNotAllowed += PlayNoSymbol;
        Kid.OnTeleportNotAllowed += PlayNoSymbol;
        Adult.OnTeleportNotAllowed += PlayNoSymbol;
    }

    private void OnDisable()
    {
        SwitchCharacter.OnSwitchNotAllowed -= PlayNoSymbol;
        Kid.OnTeleportNotAllowed -= PlayNoSymbol;
        Adult.OnTeleportNotAllowed -= PlayNoSymbol;
    }

    private void PlayNoSymbol()
    {
        anim.Play("NoSymbol", -1, 0f);
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Cancel", gameObject);
    }
}

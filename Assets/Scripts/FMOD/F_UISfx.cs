using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_UISfx : MonoBehaviour
{

    public void UISelect()
    {

    }

    public void UISubmit()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/UI", gameObject);
    }

    public void UIBack()
    {

    }

    public void GameStart()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Game Start", gameObject);
    }

}

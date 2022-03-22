using UnityEngine;
using FMODUnity;

public class F_UISfx : MonoBehaviour
{

    public void UISelect()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Select", gameObject);
    }

    public void UISubmit()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Submit", gameObject);
    }

    public void UIBack()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Back", gameObject);
    }

    public void UIRebindWait()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Rebind Waiting", gameObject);
    }

    public void UIRebindReceived()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Rebind Received", gameObject);
    }

    public void GameStart()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Game Start", gameObject);
    }
}

using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_GameplaySfx : MonoBehaviour
{
    public void PlayFootstepChildSfx()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/Young/Footsteps", gameObject);
    }

    public void PlayFootstepAdultSfx()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/Old/Footsteps", gameObject);
    }

    public void PlayCratePickupSfx()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/Interactables/Crate Pickup", gameObject);
    }


    private EventInstance TonalAmb;
    private EventInstance ForestAmb;

    private void Start()
    {
        TonalAmb = RuntimeManager.CreateInstance("event:/SFX/Ambience/Tonal Amb");
        ForestAmb = RuntimeManager.CreateInstance("event:/SFX/Ambience/Forest Amb");

        TonalAmb.start();
        TonalAmb.release();
        ForestAmb.start();
        ForestAmb.release();
    }

    private void OnDestroy()
    {
        TonalAmb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        ForestAmb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

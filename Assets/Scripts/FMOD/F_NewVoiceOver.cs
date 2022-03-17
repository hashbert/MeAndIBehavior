using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_NewVoiceOver : MonoBehaviour
{
    EventInstance dialogueEvent;
    EventInstance dialoguePlaying;

    [SerializeField]
    private EventReference _vOLine;

    private PLAYBACK_STATE pb;

    void Start()
    {
        dialogueEvent = RuntimeManager.CreateInstance(_vOLine);
        dialogueEvent.start();
        dialoguePlaying = RuntimeManager.CreateInstance("snapshot:/Dialogue Over Music");
    }

    private void Update()
    {
        dialogueEvent.getPlaybackState(out pb);
        if (pb == PLAYBACK_STATE.STARTING)
            dialoguePlaying.start();
        else if (pb == PLAYBACK_STATE.STOPPED || pb == PLAYBACK_STATE.STOPPING)
            dialoguePlaying.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void ContinueVO()
    {
        if (pb == PLAYBACK_STATE.PLAYING)
        {
            dialogueEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            dialogueEvent.start();
        }
        else
            dialogueEvent.start();
    }

    private void OnDestroy()
    {
        dialogueEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        dialoguePlaying.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        dialogueEvent.release();
        dialoguePlaying.release();
    }
}

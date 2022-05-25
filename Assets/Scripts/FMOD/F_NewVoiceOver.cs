using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_NewVoiceOver : MonoBehaviour
{
    public EventInstance dialogueEvent;
    EventInstance dialoguePlaying;

    [SerializeField]
    private EventReference _vOLine;

    [HideInInspector]
    public PLAYBACK_STATE voPb;
    private PLAYBACK_STATE _MusicEffectPb;

    void Start()
    {
        if (F_MusicPlayer.instance.SceneRepeated) return;
        dialogueEvent = RuntimeManager.CreateInstance(_vOLine);
        dialogueEvent.start();
        dialoguePlaying = RuntimeManager.CreateInstance("snapshot:/Dialogue Over Music");
    }

    private void Update()
    {
        dialogueEvent.getPlaybackState(out voPb);
        dialoguePlaying.getPlaybackState(out _MusicEffectPb);
        if (voPb == PLAYBACK_STATE.STARTING && _MusicEffectPb != PLAYBACK_STATE.PLAYING)
            dialoguePlaying.start();
        else if (voPb == PLAYBACK_STATE.STOPPED)
            dialoguePlaying.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void ContinueVO()
    {
        if (voPb == PLAYBACK_STATE.PLAYING)
        {
            dialogueEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            dialogueEvent.start();
        }
        else
            dialogueEvent.start();
    }

    private void OnDestroy()
    {
        if (voPb != PLAYBACK_STATE.STOPPED)
            dialogueEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        dialoguePlaying.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        dialogueEvent.release();
        dialoguePlaying.release();
    }
}

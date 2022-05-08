using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_NewVoiceOver : MonoBehaviour
{
    EventInstance dialogueEvent;
    EventInstance dialoguePlaying;

    [SerializeField]
    private EventReference _vOLine;

    private PLAYBACK_STATE _VoPb;
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
        dialogueEvent.getPlaybackState(out _VoPb);
        dialoguePlaying.getPlaybackState(out _MusicEffectPb);
        if (_VoPb == PLAYBACK_STATE.STARTING && _MusicEffectPb != PLAYBACK_STATE.PLAYING)
            dialoguePlaying.start();
        else if (_VoPb == PLAYBACK_STATE.STOPPED)
            dialoguePlaying.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void ContinueVO()
    {
        if (_VoPb == PLAYBACK_STATE.PLAYING)
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

using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_VoiceOver : MonoBehaviour
{
    private EventInstance _voiceOverEvent;

    [SerializeField]
    private string _eventPath;

    private

    void Start()
    {
        _voiceOverEvent = RuntimeManager.CreateInstance("event:/Dialogue/" + _eventPath);
        _voiceOverEvent.start();
    }

    private void OnDestroy() {
        _voiceOverEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}

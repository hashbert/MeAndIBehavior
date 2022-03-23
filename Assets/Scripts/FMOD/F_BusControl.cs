using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;


public class F_BusControl : MonoBehaviour
{
    private Bus _bus;
    public string BusPath;
    [SerializeField] private Slider _slider;
    private EventInstance _levelTest;
    private PLAYBACK_STATE _pb;

    private void Start()
    {
        _bus = RuntimeManager.GetBus("bus:/" + BusPath);
        _bus.getVolume(out float volume);
        _slider.value = volume * _slider.maxValue;

        if (BusPath == "SFX")
        {
            _levelTest = RuntimeManager.CreateInstance("event:/SFX/UI/Submit");
        }
        else
            _levelTest.release();
    }


    public void VolumeChange()
    {
        _bus.setVolume(_slider.value / _slider.maxValue);
        if (BusPath == "SFX")
         {
            _levelTest.getPlaybackState(out _pb);
            if (_pb != PLAYBACK_STATE.PLAYING)
                _levelTest.start();
         }
     }

    private void OnDestroy()
    {
        _levelTest.release();
    }
}

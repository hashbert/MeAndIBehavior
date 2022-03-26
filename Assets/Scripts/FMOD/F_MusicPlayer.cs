using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class F_MusicPlayer : MonoBehaviour
    {
    public EventReference _menuMusic;
    public EventReference _gameplayMusic;
    public EventInstance MenuMusicInst;
    public EventInstance GameplayMusicInst;
    private EventInstance CurrentMusicInst;

    private static F_MusicPlayer _instance;
    public static F_MusicPlayer instance {
        get {
            if (_instance == null) {
                Object.Instantiate(Resources.Load<F_MusicPlayer>("Prefabs/MusicObject"));
            }
            return _instance;
        }

        private set => _instance = value;
    }

    private EventDescription EventDes;
    private PARAMETER_DESCRIPTION ParamDes;

    void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("music player created");
        } else {
            Destroy(this.gameObject);
            Debug.Log("music player destroyed");
        }
    }

    void Start() {
        MenuMusicInst = RuntimeManager.CreateInstance(_menuMusic);
        GameplayMusicInst = RuntimeManager.CreateInstance(_gameplayMusic);
        Scene currentScene = SceneManager.GetActiveScene();
        PlayMusicForCurrentScene(currentScene, currentScene);
        SceneManager.activeSceneChanged += PlayMusicForCurrentScene;

        EventDes = RuntimeManager.GetEventDescription("event:/Music/Gameplay Music");
        EventDes.getParameterDescriptionByName("CharacterSwitch", out ParamDes);
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= PlayMusicForCurrentScene;
    }

    private SceneMusicData sceneMusicData;
    private MusicType currentMusicType;
    private void PlayMusicForCurrentScene(Scene oldScene, Scene newScene) {
        sceneMusicData = FindObjectOfType<SceneMusicData>();
        Debug.Log("gimme a break");
        if (sceneMusicData == null) return;

        MusicType nextSceneMusic = sceneMusicData.music;
        Debug.Log("hasn't been cut off yet");
        if (currentMusicType == nextSceneMusic) return;
        Debug.Log("hasn't been cut off yet1");
        StopCurrentMusic();
        Debug.Log("hasn't been cut off yet2");
        EventInstance musicToStart;
        if (newScene.name == "MainMenuScene") {
            musicToStart = MenuMusicInst;
            currentMusicType = MusicType.MainMenu;
            Debug.Log("This is the MainMenuScene");
        } else if (SceneManager.GetActiveScene().name.Contains("Cutscene")) {
            instance.SetMusicParameter(3f);
            musicToStart = GameplayMusicInst;
            currentMusicType = MusicType.Gameplay;
            Debug.Log("This is a Cutscene");
        } else {
            musicToStart = GameplayMusicInst;
            currentMusicType = MusicType.Gameplay;
            Debug.Log("This is any other level");
        }
        StartMusic(musicToStart);
    }

    private void StopCurrentMusic() {
        CurrentMusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //CurrentMusicInst.release();
        Debug.Log("Stop music called");
    }

    private void StartMusic(EventInstance music) {
        music.start();
        //music.release();
        CurrentMusicInst = music;
        Debug.Log("Start Music called");
    }

    public void SetMusicParameter(float value) {
        GameplayMusicInst.setParameterByID(ParamDes.id, value);
    }
}
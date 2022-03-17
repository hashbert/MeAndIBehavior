using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType {
    None,
    MainMenu,
    Gameplay
}

public class SceneMusicData : MonoBehaviour {
    public MusicType music;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject[] questions;
    [SerializeField] private GameObject fader;
    void OnEnable()
    {
        var level = PlayerPrefs.GetInt("Level");
        for(int i = 0; i<level; i++)
        {
            levels[i].SetActive(true);
            questions[i].SetActive(false);
        }
    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("Level", 0);
        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }
        foreach (GameObject question in questions)
        {
            question.SetActive(true);
        }
    }

    public void LevelChosen(int level)
    {
        fader.SetActive(true);
        fader.GetComponent<Fader>().SetNextSceneName("Level" + level);
    }
}

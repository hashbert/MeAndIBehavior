using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartCurrentLevel();
    }
    public void RestartCurrentLevel()
    {
        fader.GetComponent<Fader>().SetNextSceneName(SceneManager.GetActiveScene().name);
        fader.SetActive(true);
    }
}

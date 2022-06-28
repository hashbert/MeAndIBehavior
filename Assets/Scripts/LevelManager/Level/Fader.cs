using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fader : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    private Animator anim;
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.Play("Fader");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void SetNextSceneName(string level)
    {
        nextSceneName = level;
    }
}

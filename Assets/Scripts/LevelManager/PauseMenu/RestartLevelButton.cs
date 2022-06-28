using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevelButton : MonoBehaviour
{
    [SerializeField] private Animator _ltTrigger;
    [SerializeField] private Animator _rtTrigger;
    [SerializeField] private Animator _plus;
    [SerializeField] private Animator _backspace;

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FadeImagesIn()
    {
        _ltTrigger.enabled = true;
        _ltTrigger.Play("FadeIn", -1, 0f);
        _rtTrigger.enabled = true;
        _rtTrigger.Play("FadeIn", -1, 0f);
        _plus.enabled = true;
        _plus.Play("FadeIn", -1, 0f);
        _backspace.enabled = true;
        _backspace.Play("FadeIn", -1, 0f);
    }

    public void FadeImagesOut()
    {
        _ltTrigger.Play("FadeOut", -1, 0f);
        _rtTrigger.Play("FadeOut", -1, 0f);
        _plus.Play("FadeOut", -1, 0f);
        _backspace.Play("FadeOut", -1, 0f);
    }
}

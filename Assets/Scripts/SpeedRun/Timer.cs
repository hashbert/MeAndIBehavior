using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text _textTimer;
    private bool _isTimerOn = false;
    private float _timer = 0.0f;
    public static Timer instance;
    public Animator anim;
    public GameObject TimerSingleton;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += ResetTimeOnSpeed01;
        SceneManager.activeSceneChanged += ShowFinalSpeedScore;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= ResetTimeOnSpeed01;
        SceneManager.activeSceneChanged -= ShowFinalSpeedScore;
    }
    private void Update()
    {
        if (_isTimerOn)
        {
            _timer += Time.deltaTime;
            DisplayTime();
        }
    }

    private void ResetTimeOnSpeed01(Scene oldScene, Scene newScene)
    {
        if (SceneManager.GetActiveScene().name.Equals("Speed01"))
        {
            ResetTimer();
            StartTimer();
            anim.Play("ResetPosition", -1, 0f);
        }
        else if (SceneManager.GetActiveScene().name.Equals("MainMenuScene"))
        {
            Destroy(TimerSingleton);
        }
    }
    private void ShowFinalSpeedScore(Scene oldScene, Scene newScene)
    {
        if (SceneManager.GetActiveScene().name.Equals("SpeedRun"))
        {
            StopTimer();
            anim.Play("ShowFinalScore", -1, 0f);
        }
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(_timer / 60.0f);
        int seconds = Mathf.FloorToInt(_timer - minutes * 60);
        _textTimer.text = string.Format("Speed Run Time: " + "{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        _isTimerOn = true;
    }

    public void StopTimer()
    {
        _isTimerOn = false;
    }
    public void ResetTimer()
    {
        _timer = 0.0f;
    }
}

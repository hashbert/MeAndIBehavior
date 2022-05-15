using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private string nameOfScene;

    public Transform initialAdultTransform;
    public Transform initialKidTransform;

    public Transform AdultTransform;
    public Transform KidTransform;

    public static CheckpointManager instance;
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
        SceneManager.activeSceneChanged += GetInitialPositions;
        SceneManager.activeSceneChanged += CheckIfSameLastScene;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= CheckIfSameLastScene;
        SceneManager.activeSceneChanged -= GetInitialPositions;
    }

    private void GetInitialPositions(Scene arg0, Scene arg1)
    {
        initialAdultTransform = GameObject.FindGameObjectWithTag("Adult")?.transform;
        initialKidTransform = GameObject.FindGameObjectWithTag("Kid")?.transform;
    }
    private void CheckIfSameLastScene(Scene arg0, Scene arg1)
    {
        if (nameOfScene != SceneManager.GetActiveScene().name)
        {
            AdultTransform = initialAdultTransform;
            KidTransform = initialKidTransform;
        }

        nameOfScene = SceneManager.GetActiveScene().name;
    }
}

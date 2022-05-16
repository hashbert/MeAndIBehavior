using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private string nameOfScene;

    public Transform initialAdultTransform = null;
    public Transform initialKidTransform = null;

    public Vector3 checkpointAdultPosition;
    public Vector3 checkpointKidPosition;

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
        if (initialAdultTransform == null)
        {
            nameOfScene = SceneManager.GetActiveScene().name;
            return;
        }
        
        if (nameOfScene != SceneManager.GetActiveScene().name)
        {
            checkpointAdultPosition = initialAdultTransform.position;
            checkpointKidPosition = initialKidTransform.position;
        }

        nameOfScene = SceneManager.GetActiveScene().name;
    }
}

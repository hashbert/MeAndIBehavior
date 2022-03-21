using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class InputManager : MonoBehaviour
{
    //static player input class for all to access
    public static PlayerInput playerInput;

    //saving level Number to player prefs
    private int? levelNumber;
    //getting Scene name for restarting
    private string sceneName;

    public void OnRestartInput(InputAction.CallbackContext _)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        playerInput = GetComponent<PlayerInput>();

        levelNumber = TryToExtractLevelFromSceneName(sceneName);
        if (levelNumber.HasValue)
        {
            var highestLevel = PlayerPrefs.GetInt("Level");
            levelNumber = levelNumber < highestLevel ? levelNumber = highestLevel : levelNumber;
        }
    }

    private void Start()
    {
        if (levelNumber.HasValue)
        {
            PlayerPrefs.SetInt("Level", levelNumber.Value);
        }
        else
        {
            Debug.LogWarning($"No level number found from scene name {sceneName} - nothing to save to player prefs");
        }
    }


    private static int? TryToExtractLevelFromSceneName(string sceneName, int suffixLength=2)
    {
        Debug.Assert(suffixLength >= 1 && suffixLength < sceneName.Length,
            "Suffix must be non empty and shorter than sceneName");

        string sceneNameSuffix = sceneName.Substring(sceneName.Length - suffixLength);
        if (int.TryParse(sceneNameSuffix, out int levelNumber))
        {
            return levelNumber;
        }
        else
        {
            Debug.LogWarning($"Expected scene name '{sceneName}' to end with {suffixLength} digits. " +
                             $"If this is a template scene, try copying the scene and renaming to end with {suffixLength} digits");
            return null;
        }
    }
}

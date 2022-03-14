using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject continueButton;
    [SerializeField] [TextArea(3, 10)] private string[] sentences;
    private int sentenceNum = 0;
    private int lettersRevealed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplaySentence());
    }

    IEnumerator DisplaySentence()
    {
        string currentSentence = sentences[sentenceNum];
        int totalCharInSentence = currentSentence.Length;

        textBox.text = currentSentence;

        lettersRevealed = 0;
        for (lettersRevealed = 0; lettersRevealed <= totalCharInSentence; lettersRevealed++)
        {
            textBox.maxVisibleCharacters = lettersRevealed;
            yield return new WaitForSeconds(typingSpeed);
        }

        //for (int i = 0; i <= totalCharInSentence; i++)
        //{
        //    textBox.maxVisibleCharacters = i;
        //    yield return new WaitForSeconds(typingSpeed);
        //}

        sentenceNum++;

        if (sentenceNum < sentences.Length)
        {
            downArrow.SetActive(true);
        }
        else
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        downArrow.SetActive(false);
        StartCoroutine(DisplaySentence());
    }

    public void Continue()
    {
        continueButton.SetActive(false);
        SceneManager.LoadScene("Level1");
    }

    private readonly InputAction _anyKeyWait = new InputAction(binding: "/*/<button>", type: InputActionType.Button);
    private void Awake() => _anyKeyWait.performed += DoSomething;
    private void OnEnable() => _anyKeyWait.Enable();
    private void OnDisable() => _anyKeyWait.Disable();
    private void OnDestroy() => _anyKeyWait.performed -= DoSomething;
    private void DoSomething(InputAction.CallbackContext ctx) => AnyKey();
    private void AnyKey()
    {
        lettersRevealed = 2147483646;
        textBox.maxVisibleCharacters = lettersRevealed;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    [SerializeField] [TextArea(3, 10)] private string[] sentences;
    [SerializeField] private bool[] kidTalking;

    [SerializeField] private Animator kidAnim;
    [SerializeField] private Animator adultAnim;
    
    [SerializeField] private TextMeshProUGUI kidText;
    [SerializeField] private TextMeshProUGUI adultText;

    [SerializeField] private GameObject kidSpeechBubble;
    [SerializeField] private GameObject adultSpeechBubble;

    [SerializeField] private float typingSpeed = 0.02f;
    [SerializeField] private GameObject fader;

    private int sentenceNum = 0;
    private int totalCharInSentence;
    private int lettersRevealed;



    void Start()
    {
        kidAnim.enabled = false;
        adultAnim.enabled = false;
        StartCoroutine(DisplaySentence());
    }

    IEnumerator DisplaySentence()
    {
        string currentSentence = sentences[sentenceNum];
        totalCharInSentence = currentSentence.Length;

        if (kidTalking[sentenceNum])
        {
            adultSpeechBubble.SetActive(false);
            adultAnim.enabled = false;
            kidSpeechBubble.SetActive(true);
            kidAnim.enabled = true;
            
            kidText.text = currentSentence;

            lettersRevealed = 0;
            for (lettersRevealed = 0; lettersRevealed <= totalCharInSentence; lettersRevealed++)
            {
                kidText.maxVisibleCharacters = lettersRevealed;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        else if (!kidTalking[sentenceNum])
        {
            adultSpeechBubble.SetActive(true);
            adultAnim.enabled = true;
            kidSpeechBubble.SetActive(false);
            kidAnim.enabled = false;

            adultText.text = currentSentence;

            lettersRevealed = 0;
            for (lettersRevealed = 0; lettersRevealed <= totalCharInSentence; lettersRevealed++)
            {
                adultText.maxVisibleCharacters = lettersRevealed;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        sentenceNum++;


    }

    private readonly InputAction _anyKeyWait = new InputAction(binding: "/*/<button>", type: InputActionType.Button);
    private void Awake() => _anyKeyWait.performed += DoSomething;
    private void OnEnable() => _anyKeyWait.Enable();
    private void OnDisable() => _anyKeyWait.Disable();
    private void OnDestroy() => _anyKeyWait.performed -= DoSomething;
    private void DoSomething(InputAction.CallbackContext ctx) => AnyKey();
    private void AnyKey()
    {
        if (sentenceNum >= sentences.Length)
        {
            fader.GetComponent<Fader>().SetNextSceneName(nextSceneName);
            fader.SetActive(true);
        }
        else if (lettersRevealed < totalCharInSentence)
        {
            lettersRevealed = totalCharInSentence;
            kidText.maxVisibleCharacters = lettersRevealed;
            adultText.maxVisibleCharacters = lettersRevealed;
        }
        else
        {
            StartCoroutine(DisplaySentence());
        }
    }
}

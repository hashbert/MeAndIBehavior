using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject continueButton;
    [SerializeField] [TextArea(3, 10)] private string[] sentences;
    private int sentenceNum = 0;

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
        for (int i = 0; i <= totalCharInSentence; i++)
        {
            textBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }

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
}

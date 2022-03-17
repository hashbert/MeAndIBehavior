using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] [TextArea(3, 10)] private string[] sentences; 
    private int numberOfSentences;
    private int currentSentence = 0;
    //private int currentCharacter = 0;

    private TextMeshProUGUI textBox;
    [SerializeField] float typeSpeed = 0.02f;


    private void Awake()
    {
        textBox = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        numberOfSentences = sentences.Length;
        StartCoroutine(DisplayText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DisplayText()
    {
        int totalCharInSentence = sentences[currentSentence].Length;
        textBox.text = sentences[currentSentence];
        for (int i = 0; i <= totalCharInSentence; i++)
        {
            textBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void NextSentence()
    {

    }

    public void Continue()
    {
        NextSentence();
    }
}

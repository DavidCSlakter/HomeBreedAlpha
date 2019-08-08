using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class textBoxController : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI characterName;
    public GameObject questionPanel;
    public string textfilePath;


    [Header("Text Speed")]
    public float textSpeed;

    string outputString = null;
    private bool finished;
    private bool askingAnotherQuestion;
    private bool readingAnotherAnswerLine;
    private int i;

    string currentLine = null;
    string currentDialogue = null;
    public StreamReader reader;

    string[] answerLines = new string[0];
    int answerInd = 0;

    QuestionPanelController questionScript;

    void Awake()
    {
        // Set the text
        textfilePath = "Assets/Dialogue/" + textfilePath;
        reader = new StreamReader(textfilePath);
        questionScript = (QuestionPanelController)questionPanel.GetComponent(typeof(QuestionPanelController));
        readNewLine();
        
    }
    public void answerQuestion (string [] answer, bool LastQuestion)
    {
        answerLines = answer;
        answerInd = 0;
        readAnotherAnswerLine(answerInd);

        if (!LastQuestion)
        {
            askingAnotherQuestion = true;
        }
        

    }
    void readAnotherAnswerLine(int ind)
    {
        i = -1;
        finished = false;
        outputString = null;
        characterName.text = transform.parent.name;
        currentDialogue = answerLines[ind];
        StartCoroutine("delay");
    }

    public void readNewLine()
    {
        currentLine = reader.ReadLine();
        if (currentLine != null)
        {


            if (currentLine.Contains("["))
            {
                dialogue.text = "";
                gameObject.SetActive(false);
                questionPanel.SetActive(true);


                string[] questions = currentLine.Split('[');
                for (int q = 0; q < questions.Length; q++)
                {
                    string[] questionAnswer = questions[q].Split('%');
                    string[] answerLines = questionAnswer[1].Split('/');
                    questionScript.setQuestion(questionAnswer[0], q);
                    questionScript.setAnswer(answerLines, q);
                }
                for (int q = 0; q < 4 - questions.Length; q++)
                {
                    questionScript.setQuestion("", 3 - q);
                }

            }
            else
            {
                i = -1;
                finished = false;
                outputString = null;
                int ind = currentLine.IndexOf(',');
                characterName.text = currentLine.Substring(0, ind);
                currentDialogue = currentLine.Substring(ind + 1, currentLine.Length - ind - 1);
                StartCoroutine("delay");
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            
        {
            answerInd++;
            if (!finished)
            {
                StopCoroutine("delay");
                dialogue.text = currentDialogue;
                finished = true;
            }
            else
            {
                if (answerInd < answerLines.Length)
                {
                    readAnotherAnswerLine(answerInd);
                }
                else if (askingAnotherQuestion)
                {
                    gameObject.SetActive(false);
                    questionPanel.SetActive(true);
                    dialogue.text = "";
                    askingAnotherQuestion = false;
                }
                else
                {
                    readNewLine();
                }
                
            }
        }
    }

    private string Typewrite(string text)
    {
        i++;
        char[] characters = text.ToCharArray();
        outputString = outputString + characters[i].ToString();

        if(i == (characters.Length - 1))
        {
            finished = true;
            StopCoroutine("delay");
           
        }
        return outputString;
        
    }

    IEnumerator delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(textSpeed);

            if (!finished)
            {
                dialogue.text = Typewrite(currentDialogue);
            }
        }
  

    }


}

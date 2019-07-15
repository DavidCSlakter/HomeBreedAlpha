using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionPanelController : MonoBehaviour
{
    public TextMeshProUGUI question0;
    public TextMeshProUGUI question1;
    public TextMeshProUGUI question2;
    public TextMeshProUGUI question3;
    public RectTransform selectedPanelTransform;

    public GameObject dialogueBox;


    private string [] question0Answer;
    private string [] question1Answer;
    private string [] question2Answer;
    private string [] question3Answer;

    textBoxController textBoxScript;

    int selected = 0;
    int numOfQuestions = 0;
    int numOfQuestionsAnswered = 0;

    bool question0Answered;
    bool question1Answered;
    bool question2Answered;
    bool question3Answered;



    // Start is called before the first frame update
    void Start()
    {
        textBoxScript = (textBoxController)dialogueBox.GetComponent(typeof(textBoxController));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            bool lastQuestion = false;
            
            dialogueBox.SetActive(true);
            gameObject.SetActive(false);

            if (selected == 0)
            {
                if (!question0Answered)
                {
                    numOfQuestionsAnswered++;
                    question0Answered = true;

                    if (numOfQuestionsAnswered == numOfQuestions)
                    {
                        lastQuestion = true;
                    }
                }
                textBoxScript.answerQuestion(question0Answer, lastQuestion);
                question0.color = Color.gray;
            }
            else if (selected == 1)
            {
                if (!question1Answered)
                {
                    numOfQuestionsAnswered++;
                    question1Answered = true;

                    if (numOfQuestionsAnswered == numOfQuestions)
                    {
                        lastQuestion = true;
                    }
                }
                textBoxScript.answerQuestion(question1Answer, lastQuestion);
                question1.color = Color.gray;
            }
            else if (selected == 2)
            {
                if (!question2Answered)
                {
                    numOfQuestionsAnswered++;
                    question2Answered = true;

                    if (numOfQuestionsAnswered == numOfQuestions)
                    {
                        lastQuestion = true;
                    }
                }
                textBoxScript.answerQuestion(question2Answer, lastQuestion);
                question2.color = Color.gray;
            }
            else if (selected == 3)
            {
                if (!question2Answered)
                {
                    numOfQuestionsAnswered++;
                    question2Answered = true;

                    if (numOfQuestionsAnswered == numOfQuestions)
                    {
                        lastQuestion = true;
                    }
                }
                textBoxScript.answerQuestion(question3Answer, lastQuestion);
                question3.color = Color.gray;
            }
            
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S))) && (selected < numOfQuestions-1))
        {
           
            selected++;
            selectedPanelTransform.localPosition += Vector3.down * 195;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W))) && (selected > 0))
        {
            selected--;
            selectedPanelTransform.localPosition += Vector3.up * 195;
        }

       
    }

    public void setQuestion(string text, int ind)
    {
        if (ind == 0)
        {
            question0.text = text;

        }
        else if (ind == 1)
        {
            question1.text = text;
        }
        else if (ind == 2)
        {
            question2.text = text;
        }
        else
        {
            question3.text = text;
        }

    }
    public void setAnswer(string[] text, int ind)
    {
        numOfQuestions++;
        if (ind == 0)
        {
            question0Answer = text;

        }
        else if (ind == 1)
        {
            question1Answer = text;
        }
        else if (ind == 2)
        {
            question2Answer = text;
        }
        else
        {
            question3Answer = text;
        }

    }
}

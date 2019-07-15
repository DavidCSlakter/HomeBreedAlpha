using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class sceneController : MonoBehaviour
{
    public Sprite[] prologueImages;
    public Image displayImage;
    public TextMeshProUGUI captionText;

    int imageNumber = 0;
    int dialogueNum = 0;
    StreamReader dialogueReader;
    string currentDialogue;
    bool finishedTyping;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueReader = new StreamReader("Assets/Dialogue/prologueDialogue.txt");
        currentDialogue = dialogueReader.ReadLine();
        currentDialogue = currentDialogue.Trim('-');
        StartCoroutine("delay");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*if (!finishedTyping) //finish current line of dialogue
            {
                StopCoroutine("delay");
                captionText.text = currentDialogue;
                finishedTyping = true;

            }*/
            if (finishedTyping)//read another line of dialogue
            {
                dialogueNum++;
                currentDialogue = dialogueReader.ReadLine();
                i = 0;
                outputString = null;
                finishedTyping = false;
                StartCoroutine("delay");
                if (currentDialogue.Contains("-")) //show new image
                {
                    imageNumber++;
                    if (imageNumber == 6)
                    {
                        displayImage.CrossFadeAlpha(0, 2.0f, false);
                  
                    }
                    else if(imageNumber == 7)
                    {
                        displayImage.sprite = prologueImages[imageNumber];
                        displayImage.CrossFadeAlpha(1.0f, 0.01f, false);
                    }
                    else
                    { 
                        displayImage.sprite = prologueImages[imageNumber];
                    }
                    currentDialogue = currentDialogue.Trim('-');
                    
                }

                

            }

        }
    }

    string outputString = null;
    int i = 0;
    private string Typewrite(string text)
    {
        
        char[] characters = text.ToCharArray();
        outputString = outputString + characters[i].ToString();

        if (i == (characters.Length - 1))
        {
            finishedTyping = true;
            StopCoroutine("delay");
        }
        i++;
        return outputString;

    }

    IEnumerator delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03f);

            if (!finishedTyping)
            {
                captionText.text = Typewrite(currentDialogue);
            }
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class sceneController : MonoBehaviour
{
    public Sprite[] prologueImages;
    public Image displayImage;
    public TextMeshProUGUI captionText;
    public Animator sceneAnimator;
    public AudioClip typingSound;
    public AudioSource typingSource;

    int imageNumber = 1;
    StreamReader dialogueReader;
    string currentDialogue;
    bool finishedTyping;
    
    // Start is called before the first frame update
    void Start()
    {
        typingSource.clip = typingSound;


        dialogueReader = new StreamReader("Assets/Dialogue/prologueDialogue.txt");
        currentDialogue = dialogueReader.ReadLine();
        currentDialogue = currentDialogue.Trim('-');
        typingSource.Play();
        StartCoroutine("delay");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (finishedTyping)//read another line of dialogue
            {
                currentDialogue = dialogueReader.ReadLine();
                print(currentDialogue);
                if (imageNumber > 6)
                {
                    sceneAnimator.SetTrigger("FadeOut");
                    //move to next scene
                }
                else
                {
                    typingSource.Play();
                    i = 0;
                    outputString = null;
                    finishedTyping = false;
                    StartCoroutine("delay");
                    if (currentDialogue.Contains("-")) //show new image
                    {
                        
                        if (imageNumber == 6)
                        {
                            displayImage.CrossFadeAlpha(0, 2.0f, false);

                        }
                        else
                        {
                            displayImage.sprite = prologueImages[imageNumber];
                        }
                        currentDialogue = currentDialogue.Trim('-');
                        imageNumber++;
                    }
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
            typingSource.Stop();
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

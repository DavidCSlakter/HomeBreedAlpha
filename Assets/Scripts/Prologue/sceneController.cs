using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class sceneController : MonoBehaviour
{
    public Animator BlackScreen;
    public GameObject CoverScreen;
    public GameObject title;
    public GameObject CreatedBy;
    public GameObject Year;

    public Sprite[] prologueImages;
    public Image displayImage;
    public TextMeshProUGUI captionText;
    public Animator sceneAnimator;
    public AudioClip typingSound;
    public AudioSource audioSource;

    int imageNumber = 1;
    StreamReader dialogueReader;
    string currentDialogue;
    bool finishedTyping;
    bool title1 = false;
    bool title2 = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = typingSound;
        audioSource.volume = 0.1f;

        StartCoroutine("delayForSceneFade");

        dialogueReader = new StreamReader("Assets/Dialogue/prologueDialogue.txt");
    }

    void StartPrologue()
    {
        currentDialogue = dialogueReader.ReadLine();
        currentDialogue = currentDialogue.Trim('-');
        audioSource.Play();
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
                if (imageNumber > 6)
                {
                    sceneAnimator.SetTrigger("FadeOut");
                    //move to next scene
                }
                else
                {
                    audioSource.Play();
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
            audioSource.Stop();
            StopCoroutine("delay");
        }
        i++;
        return outputString;

    }

    IEnumerator delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);

            if (!finishedTyping)
            {
                captionText.text = Typewrite(currentDialogue);
            }
        }
    }

    IEnumerator delayForSceneFade()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            if (title2)
            {
                CoverScreen.SetActive(false);
                Year.SetActive(false);
                BlackScreen.SetBool("FadeOut", false);
                StartPrologue();
                StopCoroutine("delayForSceneFade");
            }
            else if (title1)
            {
                BlackScreen.SetBool("FadeOut", true);
                
                title2 = true;
            }
            else {
                title.SetActive(false);
                CreatedBy.SetActive(false);
                Year.SetActive(true);
                BlackScreen.SetBool("FadeOut", false);
                title1 = true;
            }
        }
        
    }
   
}

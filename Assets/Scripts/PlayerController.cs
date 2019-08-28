using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    [Range(100f, 500f)]
    private float walkingSpeed;

    SceneController sceneScript;

    GameObject currentCollision = null;
    TextMeshProUGUI promptText;
    AudioSource AS;
    bool checkWalking = true;

    
    void Start()
    {
        AS = GetComponent<AudioSource>();
        sceneScript = (SceneController)gameObject.GetComponentInParent(typeof(SceneController));
        promptText = transform.GetChild(0).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        promptText.text = "";

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "talker")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            promptText.text = "Talk";
        }
        currentCollision = collision.gameObject;
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        currentCollision = null;
    }

    void Update()
    {
        //Walking
        if (!sceneScript.dialogueBox.activeSelf && !sceneScript.questionBox.activeSelf)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (transform.localPosition.x > sceneScript.getMinX()))
            {
                transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0);
                anim.SetFloat("Speed", -walkingSpeed);

                if (checkWalking)
                {
                    checkWalking = false;
                    AS.Play();
                }
                
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (transform.localPosition.x < sceneScript.getMaxX()))
            {
                transform.Translate(walkingSpeed * Time.deltaTime, 0, 0);
                anim.SetFloat("Speed", walkingSpeed);
                if (checkWalking)
                {
                    checkWalking = false;
                    AS.Play();
                }

            }
            else
            {
                anim.SetFloat("Speed", 0);
                AS.Stop();
                checkWalking = true;
                
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                if (promptText.text == "Talk")
                {
                    Talker talkScript = currentCollision.GetComponent<Talker>();
                    
                    talkScript.Talk();
                    if (talkScript.hasTalked)
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }


                }

            }
        }

        
    }

    
}

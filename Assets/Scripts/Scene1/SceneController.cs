using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SceneController : MonoBehaviour
{
    public Animator DoctorAnimator;
    public Animator PlayerAnimator;
    public GameObject dialogueBox;
    public GameObject questionBox;
    public GameObject player;
    textBoxController textBoxScript;
    TextMeshProUGUI userPrompt;


    void Awake()
    {
        //set a test frame rate
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        userPrompt = player.transform.GetChild(0).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        textBoxScript = (textBoxController)dialogueBox.GetComponent(typeof(textBoxController));
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.localPosition.x < 970.0f) && (player.transform.localPosition.x > 700.0f))
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            userPrompt.text = "Hide";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //hide the character
            }
        }
        else
        {
            player.transform.GetChild(0).gameObject.SetActive(false);
        }


        if((textBoxScript.characterName.text == "Doctor") && dialogueBox.activeSelf)
        {
            DoctorAnimator.SetBool("isTalking", true);
        }
        else
        {
            DoctorAnimator.SetBool("isTalking", false);
        }
        if ((textBoxScript.characterName.text == "Lucas") && dialogueBox.activeSelf)
        {
            PlayerAnimator.SetBool("isTalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("isTalking", false);
        }
        
    }
}

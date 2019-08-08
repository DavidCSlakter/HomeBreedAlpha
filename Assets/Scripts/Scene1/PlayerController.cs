using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    [Range(100f, 1000f)]
    private float walkingSpeed;

    private float MaxX;
    private float MinX;

    SceneController sceneScript;
    
    // Start is called before the first frame update
    void Start()
    {
        MaxX = 1050.0f;
        MinX = -1020.0f;
        sceneScript = (SceneController)gameObject.GetComponentInParent(typeof(SceneController));
    }

    // Update is called once per frame
    void Update()
    {
        if (!sceneScript.dialogueBox.activeSelf && !sceneScript.questionBox.activeSelf)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (transform.localPosition.x > MinX))
            {
                transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0);
                anim.SetFloat("Speed", -walkingSpeed);
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (transform.localPosition.x < MaxX))
            {
                transform.Translate(walkingSpeed * Time.deltaTime, 0, 0);
                anim.SetFloat("Speed", walkingSpeed);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    [Range(100f, 500f)]
    private float walkingSpeed;

    SceneController sceneScript;
    
    // Start is called before the first frame update
    void Start()
    { 
        
        sceneScript = (SceneController)gameObject.GetComponentInParent(typeof(SceneController));
    }

    // Update is called once per frame
    void Update()
    {
        //Walking
        if (!sceneScript.dialogueBox.activeSelf && !sceneScript.questionBox.activeSelf)
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && (transform.localPosition.x > sceneScript.getMinX()))
            {
                transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0);
                anim.SetFloat("Speed", -walkingSpeed);
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (transform.localPosition.x < sceneScript.getMaxX()))
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

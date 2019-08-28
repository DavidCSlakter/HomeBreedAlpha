using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Talker : MonoBehaviour
{
    public string dialoguePath;
    StreamReader dialogue;
    SceneController sceneScript;

   
    public bool hasTalked = false;

    private void Start()
    {
        sceneScript = (SceneController)gameObject.GetComponentInParent(typeof(SceneController));
        dialogue = new StreamReader(dialoguePath);
    }

    public void Talk()
    {
        if (hasTalked)
        {
            gameObject.tag = "Untagged";

        }
        
        sceneScript.dialogueBox.SetActive(true);
        sceneScript.textBoxScript.reader = dialogue;
        sceneScript.textBoxScript.readNewLine();
        hasTalked = true;
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SceneController : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject questionBox;
    public GameObject player;
    public TextMeshProUGUI userPrompt;
    public textBoxController textBoxScript;
    protected float MaxX;
    protected float MinX;

    void Awake()
    {
        //set a test frame rate
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        textBoxScript = (textBoxController)dialogueBox.GetComponent(typeof(textBoxController));
        userPrompt = player.transform.GetChild(0).gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        
    }

    public float getMinX(){ return MinX; }
    public float getMaxX() {  return MaxX; }

}

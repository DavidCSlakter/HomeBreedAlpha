using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuScreenController : MonoBehaviour
{
    public Animator SceneAnimator;

    public AudioClip Music;
    public AudioSource Msource;

    public RectTransform optionSelector;

    int optionSelected = 0;
    // Start is called before the first frame update
    void Start()
    {
        Msource.clip = Music;
        Msource.volume = 0.05f;
        Msource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            SceneAnimator.SetTrigger("FadeOut");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && optionSelected < 2)
        {
            optionSelector.localPosition += Vector3.down * 90;
            optionSelected++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && optionSelected > 0)
        {
            optionSelector.localPosition += Vector3.up * 90;
            optionSelected--;
        }
    }
}

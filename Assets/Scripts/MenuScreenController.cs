using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuScreenController : MonoBehaviour
{
    public Animator SceneAnimator;

    public AudioClip Music;
    public AudioSource Msource;
    // Start is called before the first frame update
    void Start()
    {
        Msource.clip = Music;
        Msource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            SceneAnimator.SetTrigger("FadeOut");
        }
    }
}

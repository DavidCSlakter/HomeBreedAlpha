using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classSceneController : MonoBehaviour
{
    public Animator LucasAnimator;
    // Start is called before the first frame update
    void Start()
    {
        LucasAnimator.SetBool("isSitting", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

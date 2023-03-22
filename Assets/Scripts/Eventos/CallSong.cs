using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSong : MonoBehaviour
{
    public AudioSource aus_;

    void Start() => aus_ = GetComponent<AudioSource>();

    void Update()
    {
        if (this.gameObject.transform.GetChild(0).gameObject.GetComponent<OpenDoon>().unlocked == false)
        {
            aus_.Play();
        }
            
    }
}

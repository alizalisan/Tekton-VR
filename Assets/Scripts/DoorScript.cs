using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {


    AudioSource [] audios;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
      //  audios[0].volume = 0.03f;
        audios[0].Play();
        print("Door opened");
        anim.SetBool("opendoor", true);

    }

    void OnTriggerExit(Collider collider)
    {
      //  audios[1].volume = 0.03f;
        audios[1].Play();
        print("Door closed");
        anim.enabled = true;
        anim.SetBool("opendoor", false);
    }

    void pauseAnimationEvent()
    {
        print("Door paused");
        anim.enabled = false;
    }
}

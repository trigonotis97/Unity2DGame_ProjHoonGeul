using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zing : MonoBehaviour
{
    public AudioClip zingSound, correct, incorrect;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.clip = zingSound;
        audio.PlayOneShot(zingSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectSound()
    {
        audio.clip = correct;
        audio.PlayOneShot(correct);
    }
    public void InorrectSound()
    {
        audio.clip = incorrect;
        audio.PlayOneShot(incorrect);
    }
}

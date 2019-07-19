using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zing : MonoBehaviour
{
    public AudioClip zingSound;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = zingSound;
        audio.PlayOneShot(zingSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

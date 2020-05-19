using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    AudioClip doorSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        doorSound = Resources.Load("EffectSounds/" + "door") as AudioClip;
        audioSource = GetComponent<AudioSource>();
    }

    public void DoorSoundPlay()
    {
        audioSource.PlayOneShot(doorSound);
    }
}

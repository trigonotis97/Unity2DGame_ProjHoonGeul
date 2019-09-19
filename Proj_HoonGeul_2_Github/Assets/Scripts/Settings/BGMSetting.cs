using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    AudioSource m_audioSource;
    GameManager m_gameManager;

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        
    }
    public void SetAudioSetting(float inputVolum)
    {
        m_audioSource.volume = inputVolum;
    }

}

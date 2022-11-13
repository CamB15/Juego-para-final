using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_sound : MonoBehaviour
{
    public AudioClip clip_chop;
    AudioSource source;
    public AudioMixerGroup mixer;

    private void Start()
    {
        source = Sound_Manager.instance.CreateASource(clip_chop, mixer, false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.Play();
        }
    }
}

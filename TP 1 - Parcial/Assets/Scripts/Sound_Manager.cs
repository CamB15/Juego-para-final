using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;
    private void Awake() => instance = this;

    public AudioSource CreateASource(AudioClip clip, AudioMixerGroup group, bool spatial3D = false)
    {
        //creamos el objeto
        GameObject go = new GameObject();
        //le agregamos un AS
        go.AddComponent<AudioSource>();
        //obtenemos ese AS
        AudioSource source = go.GetComponent<AudioSource>();
        //Le Asignamos un Clip
        source.clip = clip;

        source.outputAudioMixerGroup = group;
        //si es 3D o 2D
        if (spatial3D)
        {
            source.spatialBlend = 0f;
        }
        else
        {
            source.spatialBlend = 1f;
        }
        //lo devolvemos para que lo usen
        return source;
    }
}

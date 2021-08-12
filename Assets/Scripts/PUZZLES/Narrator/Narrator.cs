using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance { get; private set; }

    public AudioClip[] idles;
    public AudioClip[] loops;   //repetindo acoes
    public AudioClip[] instrucoes;
    public AudioClip[] nearby;
    public AudioClip[] tutorial;

    private AudioSource voicePlayer;

    private void Awake()
    {
        voicePlayer = GetComponent<AudioSource>();
        Instance = this;
    }
    public void PlayAudio(AudioClip clip)
    {
        if (!voicePlayer.isPlaying)
        {
            voicePlayer.clip = clip;
            voicePlayer.Play();
        }
    }

}

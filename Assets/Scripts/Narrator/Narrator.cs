using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance { get; private set; }

    public NarradorClipsCalls narradorClipsCalls;
    public SequencialClips sequencialClips;

    public AudioSource voicePlayer;

    private void Awake()
    {
        voicePlayer = GetComponent<AudioSource>();
        //print("voicePlayer assigned");  
        Instance = this;
        narradorClipsCalls.PlayAudio(voicePlayer, 0);
    }
    public void PlaySequentialAudios()
    {

    }
}

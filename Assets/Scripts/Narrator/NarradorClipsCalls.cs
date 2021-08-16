using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Narrador/Narrador_Clips")]
public class NarradorClipsCalls : ScriptableObject
{
    // 
    [Header("Sequencias")]
    public SequencialClips[] sequentialDialogues;
    [Header("Clips")]
    public AudioClip[] idles;
    public AudioClip[] loops;   //repetindo acoes
    public AudioClip[] instrucoes;
    public AudioClip[] nearby;
    public AudioClip[] tutorial;

    public void PlayAudio(AudioSource source, int id)
    { 
        if (!source.isPlaying)
        {
            source.clip = GetRandomClipInArray(source, id);
            source.Play();
        }
    }
    public void Tutorial()
    {
    }
    public AudioClip GetRandomClipInArray(AudioSource source, int id) // id - tipo de clip
    {
        switch (id)
        {
            case 0: // idles
                return idles[Random.Range(0, idles.Length)];
            case 1: // loops
                return loops[Random.Range(0, idles.Length)];
            case 2: // instrucoes
                return instrucoes[Random.Range(0, idles.Length)];
            case 3: // proximos
                return nearby[Random.Range(0, idles.Length)];
            default:
                return null;
        }
    }
}

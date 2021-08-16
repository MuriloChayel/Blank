using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Narrador/SequentialClips")]
public class SequencialClips : ScriptableObject
{
    public AudioClip[] clipsInOrder;
    [SerializeField] int currentClipIndex;
    
    public bool PlayInOrder(AudioSource source)
    {
        if (currentClipIndex == clipsInOrder.Length)
            currentClipIndex = 0;
        if (currentClipIndex < clipsInOrder.Length)
        {
            if (!source.isPlaying)
            {
                source.clip = clipsInOrder[currentClipIndex];
                source.Play();
                currentClipIndex++;
            }
        }
        return source.isPlaying;
    }
}

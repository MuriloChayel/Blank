using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolvePuzzles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //esta na area da porta
        if (collision.CompareTag("doors"))
        {
            //pode procurar pela chave
            int length = Narrator.Instance.idles.Length;
            Narrator.Instance.PlayAudio(Narrator.Instance.idles[Random.Range(0, length)]);

            RoomPuzzles.Instance.canSearchKey = true;
        }
        //esta na area do item escondido
        if (collision.CompareTag("hideArea") && RoomPuzzles.Instance.canSearchKey)
        {
            //pode pegar a chave
           // int length = Narrator.Instance.nearby.Length;
            //Narrator.Instance.PlayAudio(Narrator.Instance.nearby[Random.Range(0, length)]);
            RoomPuzzles.Instance.canGetKey = true;
        }
    }
}

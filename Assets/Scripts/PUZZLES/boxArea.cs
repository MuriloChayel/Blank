using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxArea : MonoBehaviour
{
    public enum boxAreas
    {
        one = 0,
        two = 1,
        three = 2,
        four = 3,
    };

    public boxAreas areaOrder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //INDEX DA POSICAO DA AREA
            print((int)this.areaOrder);
            ResolvePuzzles.Instance.Progression((int)this.areaOrder);
        }
    }
}

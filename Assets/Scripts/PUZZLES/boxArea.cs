using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxArea : MonoBehaviour
{
    //public Levels levels
    public ResolvePuzzles resolvePuzzles;
    public bool haveAkey = false;
    public float waitTimeToShowItem;
    public enum boxAreas
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4, 
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9,
    };

    public boxAreas areaOrder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            resolvePuzzles.ReceiveBoxAreaID((int)areaOrder, 0 ,false);
            if (haveAkey)
            {
                resolvePuzzles.ReceiveBoxAreaID((int)areaOrder, waitTimeToShowItem, haveAkey);
                haveAkey = false;
            }
        }
    }
}

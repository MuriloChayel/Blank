using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get;private set;}

    public Sprite carta;
    public Sprite chave;
    public Transform prefabItemWorld;

    private void Awake()
    {
        Instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    private void Start()
    {         
        ItemWorld.SpawnItem(transform.position, item);
        Debug.Log("Spawnwed" + item.type);
        Destroy(gameObject);
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemClass.ItemType type;
    public Sprite sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;    
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}

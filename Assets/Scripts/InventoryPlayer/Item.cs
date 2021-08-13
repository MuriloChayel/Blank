using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;    
    }
    public enum ItemType
    {
        chave,
        envelope,
    };
    public ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}

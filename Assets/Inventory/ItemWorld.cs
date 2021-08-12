using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    private TextMeshPro textObject;
    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.prefabItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();

        itemWorld.SetItem(item);
        return itemWorld;
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textObject = transform.Find("textAmount").GetComponent<TextMeshPro>();
    }
    public static ItemWorld DropItem(Vector3 position, Item item)
    {
        ItemWorld itemWorld = SpawnItem(position + new Vector3(2,2,0), item);
        return itemWorld;
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1)
        {
            textObject.SetText(item.amount.ToString());
        }
        else
        {
            textObject.SetText("");
        }
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);    
    }

}


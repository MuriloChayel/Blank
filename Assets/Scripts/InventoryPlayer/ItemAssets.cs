using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public Sprite[] sprites;
    
    public Sprite GetImageSprite(Item item)
    {
        switch (item.type)
        {
            case Item.ItemType.chave:
                return sprites[0];
            case Item.ItemType.envelope:
                return sprites[1];
            default:
                return null;
        }
    }
}

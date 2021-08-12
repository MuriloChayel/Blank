using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item 
{
    public enum ItemType //identificadores 
    {
        carta,
        chave,
    }

    public ItemType type;
    public int amount;

    public Sprite GetSprite()
    {
        switch (type)
        {
            default: 
            case ItemType.carta: return ItemAssets.Instance.carta;
            case ItemType.chave: return ItemAssets.Instance.chave;
        }
    }
    public bool IsStackble()
    {
        switch (type)
        {
            default:
                case ItemType.carta: 
                case ItemType.chave:
                    return true;
            //  case itemtype == sla (n pode ser empilhado retorna false)
            //      return false
        }
    }
}


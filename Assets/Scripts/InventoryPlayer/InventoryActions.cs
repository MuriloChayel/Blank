using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActions : MonoBehaviour
{
    [Header("INVENTORY PROPERTIES")]
    private Inventory inventory;
    [SerializeField] private UI_inventory uI_Inventory;

    private void Awake()
    {
        inventory = new Inventory(UseItem);
       // uI_Inventory.SetPlayer(this);
        uI_Inventory.SetInventory(inventory);
        //Instan
    }
    private void UseItem(Item item)
    {
        switch (item.type)
        {
            case Item.ItemType.carta:
                print("Usando " + item.type);
                inventory.RemoveItem(new Item { type = Item.ItemType.carta, amount = 1 });
                break;
            case Item.ItemType.chave:
                print("Usando " + item.type);
                inventory.RemoveItem(new Item { type = Item.ItemType.chave, amount = 1 });
                break;
            default:
                print("item n encontrado!");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();

        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
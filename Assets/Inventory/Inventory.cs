using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChange;

    public List<Item> ItemList;
    private Action<Item> useItemAction;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        ItemList = new List<Item>();
        Debug.Log("Inventory");
    }
    
    public void AddItem(Item item){
        if (item.IsStackble()){
            bool itemAlredyInInventory = false;
            foreach(Item inventoryItem in ItemList){
                if(inventoryItem.type == item.type){
                    inventoryItem.amount += item.amount;
                    itemAlredyInInventory = true;
                }
            }
            if (!itemAlredyInInventory)
            {
                ItemList.Add(item);
            }
        }
        else
        {
            ItemList.Add(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItem(Item item)
    {
        if (item.IsStackble()){
            Item itemInventory = null; 
            foreach (Item InventoryItem in ItemList){
                if (InventoryItem.type == item.type){
                    InventoryItem.amount -= item.amount;
                    itemInventory = InventoryItem;
                }
            }
            if (itemInventory != null && itemInventory.amount <= 0){
                ItemList.Remove(itemInventory);
            }
        }
        else
        {
            ItemList.Remove(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }
    public List<Item> GetItemList()
    {
        return ItemList;
    }
}

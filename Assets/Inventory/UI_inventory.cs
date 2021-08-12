using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;
    private PlayerBehaviour player;

    private void Awake()
    {
        itemSlotContainer = this.transform;
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }
    //public void SetPlayer(PlayerBehaviour player)
    //{
    //    this.player = player;
    //}
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;


        inventory.OnItemListChange += Inventory_OnItemListChange;
      
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItens();
    }

    private void RefreshInventoryItens() {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
        }
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                inventory.UseItem(item);
            };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                //DROP ITEM
                Item duplicateItem = new Item { type = item.type, amount = item.amount }; 
                 inventory.RemoveItem(item);
                ItemWorld.DropItem(player.transform.position, duplicateItem);
            };

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            TextMeshProUGUI amountText = itemSlotRectTransform.Find("textAmount").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1) { 
                amountText.SetText(item.amount.ToString());
            }
            else
            {
                amountText.SetText("");
            }
            image.sprite = item.GetSprite();
        }
    }
}   

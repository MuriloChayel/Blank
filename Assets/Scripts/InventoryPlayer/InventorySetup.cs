using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySetup : MonoBehaviour
{
    public UI_inventory uI_Inventory;

    [SerializeField] public List<Item> itemList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("itens"))
        {
            Item item = collision.GetComponent<Item>();
            AddItem(item);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            UseKey(); 
    }
    public void AddItem(Item item)
    {
        SetItemProperties(item);
        print("tipo do item adquirido" + item.type);
        uI_Inventory.AddItemToCanvas(item);//newItem.sprite);
    }
    public void SetItemProperties(Item itemObj)
    {
        itemList.Add(itemObj);
    }
    //CORRIGINDO
    public void UseKey()
    {
        for (int a = 0; a < itemList.Count; a++)
        {
            if (itemList[a].type == Item.ItemType.chave)
            {
                uI_Inventory.UseItemFromCanvas(Item.ItemType.chave);
                itemList.RemoveAt(a);
            }
        }
    }
    //CORRIGINDO
    public void UseCommunItem()
    {
        for(int a = 0; a < itemList.Count; a++)
        {

        }
    }
}

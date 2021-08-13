using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_inventory : MonoBehaviour
{
    public static UI_inventory Instance { get; private set; }

    public Transform container;
    public Transform slot;
    public Image img;
    public List<Transform> icons;

    public void AddItemToCanvas(Item item)
    {
        Transform icon = Instantiate(slot, container.transform, false).transform;
        slot.gameObject.SetActive(true);
        
        img.GetComponent<Image>().useSpriteMesh = true;
        
        icon.gameObject.SetActive(true);
        icons.Add(icon);
    }
    //CORRIGINDO
    public void UseItemFromCanvas(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.chave:
                for(int a = 0; a < icons.Count; a++)
                {
                    Destroy(icons[a].gameObject);
                }
                break;
            case Item.ItemType.envelope:
                break;
            default:
                return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideItem : MonoBehaviour
{
    public KeyCode showItemKey;
    public GameObject item;
    public GameObject[] useToHide;
    
    bool canSpawn = false;
    bool inHideArea = false;

    private void Update()
    {
        canSpawn = RoomPuzzles.Instance.canSearchKey;

        if (canSpawn && Input.GetKeyDown(showItemKey) && inHideArea)
        {
            HideGo();
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inHideArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inHideArea = false;
    }

    private void HideGo()
    {
        foreach(var item in useToHide)
        {
            item.SetActive(false);
        }
    }
}

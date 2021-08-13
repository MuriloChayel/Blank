using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public static OpenDoors Instance { get; private set; }

    public InventorySetup inventorySetup;

    public GameObject door;
    public KeyCode openDoorKey;
    public bool levelComplete;
    public BoxCollider2D doorCollider;

    public bool haveAKey = false;


    //USADA PARA SABER QUANDO O PLAYER ESTA NA AREA SUFICIENTE PARA ABRIR UMA PORTA
    public bool inDoorArea = false;
   
    private void Start()
    {
        Instance = this;
        door.SetActive(false);
    }
    private void Update()
    {
        if( haveAKey && inDoorArea && Input.GetKeyDown(openDoorKey))
            OpenDoor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckIfHaveAKey();
            inDoorArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inDoorArea = false;
    }
    private void CheckIfHaveAKey()
    {
        if (inventorySetup.itemList.Count > 0)
        {
            foreach (var item in inventorySetup.itemList)
            {
                print("Key");
                if (item.type == Item.ItemType.chave)
                    haveAKey = true;
            }
        }
    }
    private void OpenDoor()
    {   door.SetActive(true);
        doorCollider.enabled = false;
    }
}

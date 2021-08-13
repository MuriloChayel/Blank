using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public static OpenDoors Instance { get; private set; }

    public InventorySetup inventorySetup;

    public KeyCode openDoorKey;
    [Header("PROPERTIES")]
    public GameObject door;
    public BoxCollider2D doorCollider;
    [Header("CHECKs")]
    public bool levelComplete;
    public bool haveAKey = false;
    public bool inDoorArea = false;
   
    private void Start()
    {
        Instance = this;
        door.SetActive(false);
    }
    //ABRIR A PORTA + USAR CHAVE
    private void Update()
    {
        if (haveAKey && inDoorArea && Input.GetKeyDown(openDoorKey))
        {
            inventorySetup.UseKey();
            OpenDoor();
        }
    }
    // CHECANDO SE POSSUI CHAVES
    private void CheckIfHaveAKey()
    {
        if (inventorySetup.itemList.Count > 0)
        {
            foreach (var item in inventorySetup.itemList)
            {
                print("Key");
                if (item.type == ItemClass.ItemType.chave)
                    haveAKey = true;
            }
        }
    }
    // OPEN DOOR
    private void OpenDoor()
    {   door.SetActive(true);
        doorCollider.enabled = false;
    }
    //CHECAGEM ABRIR PORTA - NA AREA DA PORTA --
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject door;
    public KeyCode openDoorKey;
    public bool canOpen;
    public BoxCollider2D doorCollider;

    private void Start()
    {
        door.SetActive(false);
    }
    private void Update()
    {
        if (canOpen && Input.GetKeyDown(openDoorKey) && RoomPuzzles.Instance.canOpenDoor)
            OpenDoor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpen = false;
    }
    private void OpenDoor()
    {
        door.SetActive(true);
        doorCollider.enabled = false;
    }
}

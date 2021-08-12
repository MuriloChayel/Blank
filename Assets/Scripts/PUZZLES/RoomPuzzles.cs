using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPuzzles : MonoBehaviour
{
    public static RoomPuzzles Instance { get; private set; }

    public bool canOpenDoor = false;
    public bool canGetKey = false;
    public bool canSearchKey = false;
    public bool foundKey = false;
    //FLUXO NIVEL 01

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (canGetKey)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foundKey = true;
                canOpenDoor = true;
                print("pegou!");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelProgress : MonoBehaviour
{
    public static PlayerLevelProgress Instance { get; private set; }

    public List<GameObject> itens;

    private void Awake() //primeira funcao a ser executada
    {
        Instance = this;   
    }

    public void PickItem(string name)
    {
        print("pegou o item" + name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
public class ResolvePuzzles : MonoBehaviour
{
    public static ResolvePuzzles Instance { get; private set; }

    public int quantSteps;
    public int currentStep = 0;

    [Header("Item Properties")]
    public Transform targetPosition;
    public GameObject item;

    [Header("Level Properties")]
    public bool levelComplete = false;
    public Levels level;
    public CameraBehaviour cameraBehaviours;

    [Header("Room Properties")]
    public bool playerInThisRoom;
    public Image fadeImg;
    public Vector2 camPositionsInThisRoom;
    public PlayerLevelProgress lightsSettings;

    [HideInInspector] public GameObject lightsInThisRoom;

    //[Header("level box areas")]
    [HideInInspector] public bool[] steps;
     [HideInInspector] public boxArea[] boxAreas;
    
    private void Awake()
    {
        InitLights();
        level.stepCount = InitBoxAreas();
        level.StartLevel();
        SetBoxAreasPuzzleRoom();
        Instance = this;
    }
    private void Start()
    {
     
        StartCoroutine(ActiveFirstRoomCollider());

        steps = new bool[quantSteps];
        for (int a = 0; a < quantSteps; a++)
        {
            steps[a] = new bool();
        }
    }               
    IEnumerator ActiveFirstRoomCollider()
    {
        yield return new WaitForSeconds(2);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ReceiveBoxAreaID(int idBox, float waitTime, bool haveAkey, Levels currentLevel)
    {
        if (haveAkey)
        {
            StartCoroutine(WaitALittle(waitTime, idBox, currentLevel));
        }
        else
            level.CompleteStep(idBox);
    }
    //ESPERA DE TEMPO E EXECUTA ACAO
    private IEnumerator WaitALittle(float waitTimeToShowItem, int idBox, Levels currentLevel)
    {
        yield return new WaitForSeconds(waitTimeToShowItem);
        SpawnItemInLevel(idBox, currentLevel);
    }
    //ESPERA ALGUNS SEGUNDOS PARA EXECUTAR UMA FUNCAO
    private void WaitToCallFunctions(float waitTime, string name)
    {
        //yield return new WaitForSeconds(waitTime);
        Invoke(name, waitTime);
    }
    private void SpawnItemInLevel(int idBox, Levels currentLevel) 
    {
        currentLevel.SpawnItem(idBox, item, targetPosition.position);
    }
    int count;
    
    public void InitLights()
    {
        for (int a = 0; a < transform.childCount; a++) {
            if (transform.GetChild(a).CompareTag("lights"))
            {
                lightsInThisRoom = transform.GetChild(a).gameObject;
            } 
        } 
    }
    public int InitBoxAreas()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            if (transform.GetChild(a).CompareTag("areas"))
            {
                count++;
            }
        }
        boxAreas = new boxArea[count];
        for (int a = 0; a < count; a++)
        {
            boxAreas[a] = transform.GetChild(a).GetComponent<boxArea>();
        }
        return count;
    }
    private void SetBoxAreasPuzzleRoom()
    {
        for(int a = 0; a < boxAreas.Length; a++)
        {
            boxAreas[a].GetComponent<boxArea>().resolvePuzzles = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                StartCoroutine(cameraBehaviours.FadeIn(fadeImg, camPositionsInThisRoom, lightsInThisRoom));   
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInThisRoom = false;
    }
}

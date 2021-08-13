using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolvePuzzles : MonoBehaviour
{
    public static ResolvePuzzles Instance { get; private set; }
    
    public int quantSteps;
    public int currentStep = 0;

    [Header("Item Properties")]
    public Transform targetPosition;
    public GameObject item;
    
    public Levels levels;

    public bool levelComplete = false;


    [Header("level box areas")]
    public bool[] steps;
    public boxArea[] boxAreas;

    private void Awake()
    {
        levels.level_01.stepCount = InitBoxAreas();
        SetBoxAreasPuzzleRoom();
    }
    private void Start()
    {        
        steps = new bool[quantSteps];
        for (int a = 0; a < quantSteps; a++)
        {
            steps[a] = new bool();
            print(steps[a]);
        }
    }
    public void ReceiveBoxAreaID(int idBox, float waitTime, bool haveAkey)
    {
        if (haveAkey)
        {
            StartCoroutine(WaitALittle(waitTime, idBox));
        }
        else
            levels.level_01.CompleteStep(idBox);
    }
    private IEnumerator WaitALittle(float waitTimeToShowItem, int idBox)
    {
        yield return new WaitForSeconds(waitTimeToShowItem);
        levels.level_01.SpawnItem(idBox, item, targetPosition.position);

    }
    private void Update()
    {
        
    }
    public int InitBoxAreas()
    {
        int countBoxes = transform.childCount;
        boxAreas = new boxArea[countBoxes];
        for (int a = 0; a < countBoxes; a++)
        {
            boxAreas[a] = transform.GetChild(a).GetComponent<boxArea>();
        }
        return countBoxes;
    }
    private void SetBoxAreasPuzzleRoom()
    {
        for(int a = 0; a < boxAreas.Length; a++)
        {
            boxAreas[a].GetComponent<boxArea>().resolvePuzzles = this;
        }
    }
}

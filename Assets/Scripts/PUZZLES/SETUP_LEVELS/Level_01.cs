using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Levels/level_01")]
public class Level_01 : ScriptableObject
{
    [Header("STEPS")]
    public int stepCount;
    public bool[] steps;

    [Header("COMPLETE")]
    public bool stepComplete;


    public void StartLevel()
    {
        steps = new bool[stepCount];
        for(int a = 0; a < stepCount; a++)
        {
            steps[a] = new bool();
        }
    }
    public bool CompleteLevel()
    {
        for(int a = 0; a < steps.Length; a++)
        {
            if (steps[a] == true)
                continue;
            else
                return false;
        }
        return true;
    }
    public void SpawnItem(int id, GameObject item, Vector2 position)
    {
        Instantiate(item, position, Quaternion.identity);
        CompleteStep(id);
    }
    public void CompleteStep(int id)
    {
        if (id == 0)
        {
            steps[0] = true;
        }
        else
        {
            if (steps[id - 1])
                steps[id] = true;
        }
        stepComplete = CompleteLevel();
    }

 
}

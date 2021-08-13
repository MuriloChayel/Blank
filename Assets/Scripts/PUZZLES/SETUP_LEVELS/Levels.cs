using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Level_01 level_01;
    public Transform[] levels;


    public int levelCount;


    public void Start()
    {
        level_01.StartLevel();
        levelCount = InitLevelTransformList();
    }
    private int InitLevelTransformList()
    {
        int count = transform.childCount;
        levels = new Transform[count];

        for (int a = 0; a < count; a++)
        {
            levels[a] = transform.GetChild(a);
        }
        return count;
    }
}

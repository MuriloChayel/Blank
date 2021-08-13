using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolvePuzzles : MonoBehaviour
{
    public static ResolvePuzzles Instance { get; private set; }

    public int quantSteps;
    public int currentStep = 0;
    public List<bool> steps;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        steps = new List<bool>();
        for(int a = 0; a < quantSteps; a++)
        {
            steps.Add(new bool());
        }
    }
    private void NextRoom()
    {
        steps = new List<bool>();
        for(int a = 0; a < quantSteps; a++)
        {
            steps[a] = new bool();
        }
    }
    public void Progression(int currentBoxArea)
    {
        if (currentStep < steps.Count && currentBoxArea > 0)
        {
            if (steps[currentBoxArea - 1] == true)
                steps[currentBoxArea] = true;
        }
        else if(currentBoxArea == 0)
        {
            steps[0] = true;
        }
    }
}

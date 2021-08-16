using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEnter : MonoBehaviour
{
    public static MainMenuEnter Instace { get; private set; }
    public int testNumber = 1;

    [Header("Scene Properties")]
    public Scene currentScene;
    public int sceneID;
    private void Awake()
    {
        if (Instace == null)
            Instace = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(Instace);
        currentScene = SceneManager.GetActiveScene();
        
    }
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneID = currentScene.buildIndex;
    }
    void Update()
    {
        if (Input.anyKeyDown)
            NextScene();
    }
    public void NextScene()
    {
        if (sceneID == 0)
            SceneManager.LoadScene(1);
    }
} 


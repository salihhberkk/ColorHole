using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{    
    private StandartCube[] cubes;

    internal int hapticOn;
    private int cubeCounter = 0;
    private bool gameIsOver = false;

    private GamePanel gamePanel;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    internal void StartGame()
    {
        PlayerMovement.Instance.StartHandlePlayer();
        FindCubes();
        gamePanel = FindObjectOfType<GamePanel>();
    }
    public void GameOver()
    {
        PlayerMovement.Instance.StopHandlePlayer();
        gameIsOver = true;
    }
    public void FindCubes()
    {
        cubes = FindObjectsOfType<StandartCube>();
    }
    public void CollectCube()
    {
        if (cubeCounter == cubes.Length - 1)
        {
            if (gameIsOver)
                return;
            UIManager.Instance.ShowPanel(PanelType.Win);
            PlayerMovement.Instance.StopHandlePlayer();
            return;
        }
        cubeCounter++;
    }

    public int GetCubeCounter()
    {
        return cubeCounter;
    }
    public int GetAllCubeCount()
    {
        return cubes.Length;
    }
}

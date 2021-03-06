﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadWinner()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("WinnerScene");
    }

    public void LoadStartMenu()
    {
        //load the first scene of the project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene with the name scene
        SceneManager.LoadScene("scene");

        //reset GameSession from beggining
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        //loads the scene with the name GameOver
        StartCoroutine(WaitAndLoadGameOver());
    }

    public void LoadWinnerScene()
    {
        //loads the scene with the name GameOver
        StartCoroutine(WaitAndLoadWinner());
    }

    public void QuitGame()
    {
        print("Quitting Game");
        //will only work as EXE
        Application.Quit();
    }



    

    

    

    
}


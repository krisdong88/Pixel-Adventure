using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int CurrentScene;


    private static void Awake() 
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
    }


    public static void ReloadScene()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    public static void NextScene()
    {
        SceneManager.LoadScene(++CurrentScene);
    }

    public static void PreviousScene()
    {
        SceneManager.LoadScene(--CurrentScene);
    }
}

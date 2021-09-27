using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int CurrentScene;
    private Animator[] animators;


    private void Awake() 
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        animators = GetComponentsInChildren<Animator>();
    }


    public void ReloadScene()
    {
        StartCoroutine(LoadScene(CurrentScene));
    }

    public void NextScene()
    {
        StartCoroutine(LoadScene(CurrentScene+1));
    }

    public void PreviousScene()
    {
        StartCoroutine(LoadScene(CurrentScene-1));
    }

    IEnumerator LoadScene(int index)
    {
        StartCoroutine(TransitionOut());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }


    IEnumerator TransitionOut()
    {
        for (int i = 0; i < animators.Length; i++)
        {
            
            if(i+1 %3 == 0)
                yield return new WaitForSeconds(1f);
            else
                yield return null;
            animators[i].Play("Transition_Out");
        }
            
    }
}

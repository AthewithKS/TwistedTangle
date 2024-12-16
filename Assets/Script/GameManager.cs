using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Ropes;

    public GameObject GameOverPanel;
    bool isGameOver=false;

    int currentSceneIdx = 0;
    private void OnEnable()
    {
        currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if(Ropes.transform.childCount==0 && !isGameOver)
        {
            StartCoroutine(GameWon());
        }
    }
    private IEnumerator GameWon()
    {
        yield return new WaitForSeconds(2f);
        //AudioManager.Instance.PlaySfx("Celebrate");
        GameOverPanel.SetActive(true);
        isGameOver = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(currentSceneIdx);
    }
    public void NextLeve()
    {
        if (currentSceneIdx + 1< SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIdx + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("(Max) Garbage Land");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("(Max) Aboned City)");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("(Max) PreSchoo");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("(Max) Forest");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("(Max) Castle");
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("(Max) Squingles basement");
    }
    public void LoadLevelStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
     
    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;

    public GameObject uI;

    public bool uIFalse = false;

    private void Awake()
    {
        instance = this;
    }

    public void Play()
    {
        uI.SetActive(false);
        uIFalse = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void set2Menu()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void Creadits()
    {
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void cre2Menu()
    {
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }
}

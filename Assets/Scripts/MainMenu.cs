using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script controls the MainMenu UI.
 * Setup:
 * Add this script to the canvas and then set the name of your Table level in the next level field of the inspector.
 * Tag the credits panel as "Credits"
 * 
 */


public class MainMenu : MonoBehaviour
{
    public string nextLevel;
    GameObject credits;

    public void Awake()
    {
        credits = GameObject.FindGameObjectWithTag("Credits");
        credits.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void OpenPanel()
    {
        credits.SetActive(true);
    }

    public void ClosePanel()
    {
        credits.SetActive(false);
    }
}

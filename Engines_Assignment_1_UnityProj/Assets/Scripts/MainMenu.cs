using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   //This script handles the buttons for the main menu
   //Go to about button does not require scripting since it can be done through gameobjects.

    public void StartLevel()
    {
        SceneManager.LoadScene(1); //Scene index 1 is the level
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

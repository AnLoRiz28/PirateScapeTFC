using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string WorldMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(WorldMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

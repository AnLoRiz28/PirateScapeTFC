using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string IntroAnimacion, creditos;

    public void StartGame()
    {
        SceneManager.LoadScene(IntroAnimacion);
    }

    public void Startcreditos()
    {
        SceneManager.LoadScene(creditos);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

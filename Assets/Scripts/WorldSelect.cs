using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelect : MonoBehaviour
{
    public string BoatLevel;
    public string MainMenu;

    public void boatLevel()
    {
        SceneManager.LoadScene(BoatLevel);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void IslandLevel()
    {
        
    }
}

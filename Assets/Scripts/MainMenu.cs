using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Se declaran las variables que contendrán los nombres de las escenas 
    public string IntroAnimacion, creditos, levelSelect, mainMenu;

    private void Start()
    {

    }

    //Se crea la función que carga la escena de la animacion inicial (botón de play)
    public void StartGame()
    {
        SceneManager.LoadScene(IntroAnimacion);
    }

    //Se crea la función que carga la escena de los creditos
    public void Startcreditos()
    {
        SceneManager.LoadScene(creditos);
    }

    //Se crea la función que carga la escena de selección de Nivel
    public void StartLevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

    //Función que carga la escena del Main Menu
    public void StartMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    //Se crea la función que cierra el juego
    public void QuitGame()
    {
        Application.Quit();
    }

    //Función que se encarga de hacer un sonido de bloqueo para un botçon bloqueado
    public void Bloqueado() 
    {
        AudioManager.instance.PlaySoundFX(5);
    }

    //Estas funciones se pondrán en los botones del menú principal con "OnClick"


}

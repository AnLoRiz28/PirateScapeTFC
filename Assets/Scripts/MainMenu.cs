using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Se declaran las variables que contendr�n los nombres de las escenas 
    public string IntroAnimacion, creditos, levelSelect, mainMenu;

    private void Start()
    {

    }

    //Se crea la funci�n que carga la escena de la animacion inicial (bot�n de play)
    public void StartGame()
    {
        SceneManager.LoadScene(IntroAnimacion);
    }

    //Se crea la funci�n que carga la escena de los creditos
    public void Startcreditos()
    {
        SceneManager.LoadScene(creditos);
    }

    //Se crea la funci�n que carga la escena de selecci�n de Nivel
    public void StartLevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

    //Funci�n que carga la escena del Main Menu
    public void StartMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    //Se crea la funci�n que cierra el juego
    public void QuitGame()
    {
        Application.Quit();
    }

    //Funci�n que se encarga de hacer un sonido de bloqueo para un bot�on bloqueado
    public void Bloqueado() 
    {
        AudioManager.instance.PlaySoundFX(5);
    }

    //Estas funciones se pondr�n en los botones del men� principal con "OnClick"


}

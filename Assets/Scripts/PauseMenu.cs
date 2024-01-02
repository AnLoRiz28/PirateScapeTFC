using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    
    public static PauseMenu instance;

    //Se declaran las viriables que se usarán en la clase
    public string levelSelect, mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;

    public Text coinTextPause;

    private void Awake()
    {
        instance = this;
    }

    //No se utiliza la función start
    void Start()
    {
        
    }


    //Durante toda la función update revisa si:
    void Update()
    {
        //Se pulsa el botón de menu, ene ste caso será con un onclick y un botón del canvas, y que será tactil y no con teclado.
        if (Input.GetButtonDown("Menu"))
        {
            PauseUnpause();
        }
    }

    //Se crea la función que se pondrá en el botón de pausa onclick
    public void PauseUnpause()
    {
        //Si el juego está en pausa y se pulsa en botón:
        if (isPaused)
        {
            
            isPaused = false; //La variable de en pausa se pone en false
            pauseScreen.SetActive(false); //La pantalla de pausa se pone desactivada
            Time.timeScale = 1f; //El juego se pone de nuevo en movimiento
            
        }
        else
        {
            isPaused = true; //La variable se pone en true
            pauseScreen.SetActive(true); //Se activa la pantalla de pausa
            Time.timeScale = 0f; //El tiempo del juego se pone en pausa
        }
    }


    public void FinalLevelSelect()
    {
        //Si es fidrente de null hace lo siguiente:
        if (LevelController.instance != null)
        {
            LevelController.instance.SubirNiveles(); //Carga la función de subir niveles
        }

        SceneManager.LoadScene(levelSelect); //Después carga la escena del level select
        Time.timeScale = 1f; //Por ultimo, pone el juego en movimiento por si se da el caso que esté en pausa "0f"
    }



    //Funciones que quitan el juego, cargan la escena de los niveles y la del main menu
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}

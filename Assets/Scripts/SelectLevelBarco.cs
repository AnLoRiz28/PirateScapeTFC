using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelBarco : MonoBehaviour
{
    public static SelectLevelBarco Instance;


    private void Awake()
    {
        Instance = this;
    }

    //Start Vacio
    private void Start()
    {
        
    }

    //Función que carga la escena de los niveles
    public void CambiarEscena(string nombre)
    {
        UIController.Instance.FadeToBlack();
        SceneManager.LoadScene(nombre); //Se pasa como parametro el nombre de la escena
    }


    //Función que se usa para que al pulsar en la flecha con el candado suene un sonido para indicar que está bloqueado
    public void SonidoBloqueo()
    {
        AudioManager.instance.PlaySoundFX(5); //Reproduce el sonido 5 de la lista de AudioSource
    }

}

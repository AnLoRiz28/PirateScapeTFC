using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CofreCreditos : MonoBehaviour
{
    //Se declara ka variable
    public string creditos;

    //Se declaran la variable de la imagen que saldrá de fin de juego.
    public GameObject FinDeJuego;

    //Fnción que detecta la colision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Revisa que sea el player quien colisiona
        {
            StartCoroutine(CoCreditos());

        }
    }

    public void Startcreditos()
    {
        SceneManager.LoadScene(creditos); //Esta función hace que se cargue la escene que se escriba en la variable creditos, en este caso es "Creditos"
    }

    //Esta función hace que de comienzo la corrutina y después cargar la escena de los créditos.
    public void creditosCorutine()
    {
        StartCoroutine(CoCreditos());
        Startcreditos();
    }

    //Se crea la corrutina que se encarga de poner el fundido negro, parar el juego, esperar varios segundos, poner visible el texto final etc...
    public IEnumerator CoCreditos()
    {
        AudioManager.instance.StopSoundFX(13); //Para de reproducir el sonido 13, si es que se está reproduciendo

        PlayerController.instance.stopInput = true; //El jugador deja de recibir inputs

        CameraController.instance.stopFollow = true; //La camara deja de seguir al player

        UIController.Instance.FadeToBlack(); //La pantalla se vuelve negra

        yield return new WaitForSeconds(1f); //Espera durante 1f

        FinDeJuego.SetActive(true); //La imagen con el texto de fin de juego se activa

        yield return new WaitForSeconds(5f); //Espera durante 5f

        FinDeJuego.SetActive(false); //La imagen con el texto de fin de juego se desactiva

        SceneManager.LoadScene(creditos); //Esta función hace que se cargue la escene que se escriba en la variable creditos, en este caso es "Creditos"



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    /*Se crea una función OnTriggerEnter2D, que se encarga de detectar cuando el player colisiona con este objeto y una vez ocurre,
    Usando "RespawnPlayer" instanciado del "LevelManager"*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.StopSoundFX(13); //Para de reproducir el sonido 13, si es que se está reproduciendo
            AudioManager.instance.PlaySoundFX(8); //Reproduce el sonido 8 de la lista
            LevelManager.instance.RespawnPlayer(); //Se encarga de que se ejecute la función que hace que el jugador Respawne
        }
    }
}

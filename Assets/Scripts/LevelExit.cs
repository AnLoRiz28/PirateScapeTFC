using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    //Detecta que haya una colision con el objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Revisa que sea el player quien chocó
        {
            AudioManager.instance.StopSoundFX(13); //Deja de reproducir el sonido 13 de la lista
            AudioManager.instance.PlaySoundFX(12); //Reproduce el sonido 12 de la lista
            LevelManager.instance.EndLevel(); //Llama a la función de EndLevel()
        }
    }

}

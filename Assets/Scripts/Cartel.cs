using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour
{

    //Se declara la lista de "Dialogos" que contendrá la imagen del Dialogo que se muestre
    public GameObject[] Dialogos;

    //Se crea una función que se ejecuta cada vez que se colisione con el objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Primero revisa que sea el player quien ha colisionado usando las etiquetas de los objetos
        {
            AudioManager.instance.PlaySoundFX(5); //Llama a la función creada en AudioManager.cs y reproduce el efecto que está en la pos 5 de la lista
            Dialogos[0].SetActive(true); //Hace que se muestre el objeto que está en la lista que en este caso es el dialogo
        } 
    }

    //Funciona igual que el anterior, pero detecta cuando el player deja de colisionar con el objeto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Dialogos[0].SetActive(false); //Al tener puesto false, hace lo contarrio que el anterior, hace que la imagen de dialogo desaparezca
        }
    }
}

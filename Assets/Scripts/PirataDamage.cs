using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirataDamage : MonoBehaviour
{

    //No se usan las funciones Start y Update, y que solo se usa la funci�n de la clase creada m�s abajo
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Hacemos referencia a los spikes del mapa que tienen una colision OnTrigger2D para as� que el jugador reaccione al chocar contra este objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Especificamos que solo reaccione cuando lo que choque contra el objeto tenga la etiqueta de "Player" y por lo tanto sea el jugador
        {
            PlayerHealthController.instance.PirataDealDamage();//Y llama a la funci�n de la clase PlayerHealthController, que quita vida al player
            
        }
    }
}

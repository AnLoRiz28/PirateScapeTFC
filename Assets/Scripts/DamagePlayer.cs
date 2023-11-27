using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //Hacemos referencia a los spikes del mapa que tienen una colision OnTrigger2D para así que el jugador reaccione al chocar contra este objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") //Especificamos que solo reaccione cuando lo que choque contra el objeto tenga la etiqueta de "Player" y por lo tanto sea el jugador
        {
            PlayerHealthController.instance.DealDamage(); 
            //Con una estancia llamamos a una funcion que se encuentra en el fichero PlayerHealthController, este se encarga de quitar la vida al jugador

            /*Por lo que resumiendo, si el jugador con la etiqueta "Player" colisiona contra los spikes que tienen el OnTrigger2D, activará una función
            externa que se encarga de restar una vida al jugador*/
        }
    }
}

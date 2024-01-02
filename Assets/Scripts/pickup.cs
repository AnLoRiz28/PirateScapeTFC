using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public static pickup instance;

    //Se declaran las variables booleanas para especificar que tipo de coleccionable es
    public bool isCoin, isHeal, isGem;

    //Se declara la variable para saber si está recolectado o no
    private bool isCollected;

    //Se declara el objeto que contiene la animación para cuando se recoge un coleccionable, en este caso solo las monedas
    public GameObject pickUpEffect;


    private void Awake()
    {
        instance = this;
    }


    //Fución que detecta cuando algo colisiona con el colider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected) //Si lo que colisiona es el player y además no está coleccionado este objeto:
        {
            if (isCoin) //Si es una moneda
            {
                LevelManager.instance.coinsCollected++; //Sumará uno al contador de monedas



                UIController.Instance.UpdateCoinCount(); //Actualizará en la interfaz el texto del contador de monedas

                

                Instantiate(pickUpEffect, transform.position, transform.rotation); //Además en este caso, muestra la animación al desaparecer la moneda

                AudioManager.instance.PlaySoundFX(6);

                isCollected = true; //Pone este objeto como ya coleccionado o recogido

                Destroy(gameObject); //Por último, destruye este objeto para que no se pueda volver a recoger de nuevo.
            }


            if (isHeal) //Si es un corazón
            {
                //Primero verifica que la vida del jugador sea distinta de la maxima, por lo que si ha perdido alguna vida se ejecutará, si tiene todas las vidas no lo hará
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    //Llamará a la función externa que se encarga de curar al player sumando 1 al contador de vidas y actualizando la UI
                    PlayerHealthController.instance.HealPlayer();

                    AudioManager.instance.PlaySoundFX(7);


                    isCollected = true; //Pone este objeto como ya coleccionado o recogido
                    Destroy(gameObject); //Por último, destruye este objeto para que no se pueda volver a recoger de nuevo.
                }
            }
        }
    }
}

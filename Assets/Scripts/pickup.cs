using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public static pickup instance;

    //Se declaran las variables booleanas para especificar que tipo de coleccionable es
    public bool isCoin, isHeal, isGem;

    //Se declara la variable para saber si est� recolectado o no
    private bool isCollected;

    //Se declara el objeto que contiene la animaci�n para cuando se recoge un coleccionable, en este caso solo las monedas
    public GameObject pickUpEffect;


    private void Awake()
    {
        instance = this;
    }


    //Fuci�n que detecta cuando algo colisiona con el colider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected) //Si lo que colisiona es el player y adem�s no est� coleccionado este objeto:
        {
            if (isCoin) //Si es una moneda
            {
                LevelManager.instance.coinsCollected++; //Sumar� uno al contador de monedas



                UIController.Instance.UpdateCoinCount(); //Actualizar� en la interfaz el texto del contador de monedas

                

                Instantiate(pickUpEffect, transform.position, transform.rotation); //Adem�s en este caso, muestra la animaci�n al desaparecer la moneda

                AudioManager.instance.PlaySoundFX(6);

                isCollected = true; //Pone este objeto como ya coleccionado o recogido

                Destroy(gameObject); //Por �ltimo, destruye este objeto para que no se pueda volver a recoger de nuevo.
            }


            if (isHeal) //Si es un coraz�n
            {
                //Primero verifica que la vida del jugador sea distinta de la maxima, por lo que si ha perdido alguna vida se ejecutar�, si tiene todas las vidas no lo har�
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    //Llamar� a la funci�n externa que se encarga de curar al player sumando 1 al contador de vidas y actualizando la UI
                    PlayerHealthController.instance.HealPlayer();

                    AudioManager.instance.PlaySoundFX(7);


                    isCollected = true; //Pone este objeto como ya coleccionado o recogido
                    Destroy(gameObject); //Por �ltimo, destruye este objeto para que no se pueda volver a recoger de nuevo.
                }
            }
        }
    }
}

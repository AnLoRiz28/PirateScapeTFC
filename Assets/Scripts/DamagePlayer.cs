using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    //Start y Update están vacios ya que no se usan en esta clase
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //Hacemos referencia a los objetos con esta clase, para que cuando el player choque contra el se active la función
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") //Especificamos que solo reaccione cuando lo que choque contra el objeto tenga la etiqueta de "Player" y por lo tanto sea el jugador
        {
            
            PlayerHealthController.instance.DealDamage(); 
            //Con una estancia llamamos a una funcion que se encuentra en el fichero PlayerHealthController, este se encarga de quitar la vida al jugador

            /*Por lo que resumiendo, si el jugador con la etiqueta "Player" colisiona contra el objeto que tienen el OnTrigger2D, activará una función
            externa que se encarga de restar una vida al jugador*/
        }
    }
}

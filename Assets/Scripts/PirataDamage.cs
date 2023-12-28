using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirataDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Hacemos referencia a los spikes del mapa que tienen una colision OnTrigger2D para así que el jugador reaccione al chocar contra este objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Especificamos que solo reaccione cuando lo que choque contra el objeto tenga la etiqueta de "Player" y por lo tanto sea el jugador
        {
            PlayerHealthController.instance.PirataDealDamage();
            

        }
    }
}

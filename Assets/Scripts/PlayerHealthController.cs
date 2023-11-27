using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance; //Hacemos que este script sea una estancia y así podamos usarla fuera de este fichero

    //Declaramos las dos variables que necesitamos para medir la vida, tanto la vida que tiene el jugador, como la vida máxima que puede tener
    public int currentHealth, maxHealth;

    //Declaramos los valores que se encargan de dar invencibilidad al jugador durante un tiempo determinado
    public float invincibleLenght;
    private float invincibleCounter;

    //Declaramos la variable para el sprite renderer del jugador
    private SpriteRenderer srPlayer;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        /*Indicamos que la vida que tiene el jugador sea la máxima que pueda tener, y como está dentro de la funcion start, cada vez que inicie la escena el jugador tendrá
        la máxima vida posible*/
        currentHealth = maxHealth; 

        srPlayer = GetComponent<SpriteRenderer>(); //Maramos el sprite renderer en la variable "srPlayer"
    }


    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime; //Con esta función, activamos el conteo hasta llegar a 0

            if(invincibleCounter <= 0)
            {
                //Cuando el jugador no esté en el tiempo de invencibilidad y no haya conteo, el color del jugador será el mismo y con la opacidad en 1
                srPlayer.color = new Color(srPlayer.color.r, srPlayer.color.g, srPlayer.color.b, 1f);
            }
        }
    }

    //Creamos la función que se encarga de quitar vida al jugador
    public void DealDamage()
    {
        if (invincibleCounter <= 0) //Sólo deja que el player pierda vida si el conteo ha llegado a 0
        {
            currentHealth--; //Cuando se llame a esta función, la vida del jugador disminuirá en uno, ya que estamos restando uno al currentHealth

            PlayerController.instance.aniPlayer.SetTrigger("Hurt"); //Estamos pasando al animator del player esta variable cada vez que quitamos una vida

            //Si la currentHealth (vida del jugador), llega a un valor de cero o inferior, ocurrirá lo que hay dentro del if
            if (currentHealth <= 0)
            {
                currentHealth = 0; //Indicamos que si esto ocurre, la vida del jugador se ponga a 0, por si está en un número negativo

                gameObject.SetActive(false); //Esto hace que el jugador desaparezca del mapa
            }
            else
            {
                invincibleCounter = invincibleLenght;

                //Cuando el tiempo de invencibilidad esté activo, el color del jugador cambiará y la variable que se encarga de la opacidad se pondrá en 0.5
                srPlayer.color = new Color(srPlayer.color.r, srPlayer.color.g, srPlayer.color.b,.5f);

                //Siempre que perdamos una vida, se llama a la función externa que se encarga de realizar el knockback
                PlayerController.instance.Knockback(); 
            }

            //Fuera del if(), por lo que se ejecuta siempre después de perder una vida, llama a una función externa que se encuentra en el fichero "UIController"
            UIController.Instance.UpdateHealthDisplay();
        }
        
    }
}

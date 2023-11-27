using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance; //Hacemos que este script sea una estancia y as� podamos usarla fuera de este fichero

    //Declaramos las dos variables que necesitamos para medir la vida, tanto la vida que tiene el jugador, como la vida m�xima que puede tener
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
        /*Indicamos que la vida que tiene el jugador sea la m�xima que pueda tener, y como est� dentro de la funcion start, cada vez que inicie la escena el jugador tendr�
        la m�xima vida posible*/
        currentHealth = maxHealth; 

        srPlayer = GetComponent<SpriteRenderer>(); //Maramos el sprite renderer en la variable "srPlayer"
    }


    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime; //Con esta funci�n, activamos el conteo hasta llegar a 0

            if(invincibleCounter <= 0)
            {
                //Cuando el jugador no est� en el tiempo de invencibilidad y no haya conteo, el color del jugador ser� el mismo y con la opacidad en 1
                srPlayer.color = new Color(srPlayer.color.r, srPlayer.color.g, srPlayer.color.b, 1f);
            }
        }
    }

    //Creamos la funci�n que se encarga de quitar vida al jugador
    public void DealDamage()
    {
        if (invincibleCounter <= 0) //S�lo deja que el player pierda vida si el conteo ha llegado a 0
        {
            currentHealth--; //Cuando se llame a esta funci�n, la vida del jugador disminuir� en uno, ya que estamos restando uno al currentHealth

            PlayerController.instance.aniPlayer.SetTrigger("Hurt"); //Estamos pasando al animator del player esta variable cada vez que quitamos una vida

            //Si la currentHealth (vida del jugador), llega a un valor de cero o inferior, ocurrir� lo que hay dentro del if
            if (currentHealth <= 0)
            {
                currentHealth = 0; //Indicamos que si esto ocurre, la vida del jugador se ponga a 0, por si est� en un n�mero negativo

                gameObject.SetActive(false); //Esto hace que el jugador desaparezca del mapa
            }
            else
            {
                invincibleCounter = invincibleLenght;

                //Cuando el tiempo de invencibilidad est� activo, el color del jugador cambiar� y la variable que se encarga de la opacidad se pondr� en 0.5
                srPlayer.color = new Color(srPlayer.color.r, srPlayer.color.g, srPlayer.color.b,.5f);

                //Siempre que perdamos una vida, se llama a la funci�n externa que se encarga de realizar el knockback
                PlayerController.instance.Knockback(); 
            }

            //Fuera del if(), por lo que se ejecuta siempre despu�s de perder una vida, llama a una funci�n externa que se encuentra en el fichero "UIController"
            UIController.Instance.UpdateHealthDisplay();
        }
        
    }
}

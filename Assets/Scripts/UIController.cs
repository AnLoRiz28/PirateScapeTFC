using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importamos el paquete para poder usar funciones de interfaz graficas como el tipo image por ejemplo

public class UIController : MonoBehaviour
{
    //Se declara como estancia para poder usar las funciones de este fichero fuera de el
    public static UIController Instance;

    //Declaraci�n de los 3 corazones (el heart0 realmente es el cartel de fondo pero vac�o)
    public Image heart0, heart1, heart2, heart3; 

    //Los dos estados de los corazones y los dos estados del cartel (que hace que el cartel tenga el estado de vacio y rojo)
    public Sprite heartFull, heartEmpty, heartFullFinal, heartEmptyFinal, healthBar;

    //Declaramos los 2 textos tanto de monedas como de gemas para mas adelante modificarlos en tiempo de ejecuci�n
    public Text coinText , gemsText;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleteImage;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Cada vez que comienza:
        UpdateCoinCount(); //Actualiza a 0 el contador de monedas
        UpdateGemsCount(); //Actualiza a 0 el contador de Gemas

        FadeFromBlack();
    }

    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    //Se crea la funci�n que se encarga de actualizar los corazones de la pantalla con un switch
    public void UpdateHealthDisplay()
    {
        /*Este switch que se encarga de distinguir los casos que puede haber en el canvas con las vidas al perder vidas. (Para saber cuando pierde las vidas, usa la funcion
        "currentHealth del archivo "PlayerHealthController que previamente se marc� como estancia para poder usarse fuera de su fichero.")*/
        switch (PlayerHealthController.instance.currentHealth)
        {
            //El primer caso tiene los 3 corazones llenos y el cartel llena (Quiere decir que est� sin imagen y por ello "normal")
            case 4:
                heart0.sprite = heartFullFinal; 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            //En el segundo caso, el jugador de da�a una vez y uno de los corazones desaparece (El cartel sigue vacio y normal)
            case 3:
                heart0.sprite = heartFullFinal;
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;

            //En los siguientes casos, ir�n desapareciendo los corazones a medida que se pierden vidas, mientras que el cartel se queda igual que anteriormente
            case 2:
                heart0.sprite = heartFullFinal;
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            /*En este caso, todos los corazones est�n ya borrados, y al pasar esto, se activa la cuarta y vida final, que hace que al poner "heartEmptyFinal" el cartel
            se ponga de color rojo y sin ning�n coraz�n, avisanso as� al jugador que es la �ltima vida*/
            case 1:
                heart0.sprite = heartEmptyFinal;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            //En este caso sigue todo igual que el anterior y al quedarnos sin ninguna de las 4 vidas y morir, se ver� hasta reaparecer el cartel rojo y sin vidas
            case 0:
                heart0.sprite = heartEmptyFinal;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            //Ponemos este caso default, por si ocurre alg�n otro casi fuera de lo com�n, est� controlado y no de fallo
            default:

                heart0.sprite = heartEmptyFinal;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }
    }

    //La funci�n que se encarga de actualizar el texto usando variables instanciadas de "LevelManager":
    public void UpdateCoinCount()
    {
        coinText.text = LevelManager.instance.coinsCollected.ToString(); //Actualiza el texto en el que pone el n�mero de Monedas
    }

    public void UpdateGemsCount()
    {
        gemsText.text = LevelManager.instance.gemsCollected.ToString(); //Actualiza el texto en el que pone el n�mero de Gemas
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}

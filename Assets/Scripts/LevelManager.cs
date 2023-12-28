using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance; //Se declara como una estancia


    //Declaramos el tiempo que esperará para el Respawn
    public float waitToRespawn;

    //Declaramos dos variables INT que se encargan de llevar el conteo de las monedas y gemas respectivamente
    public int coinsCollected , gemsCollected;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    //De momento no se usan estas dos funciones start y update

    void Update()
    {
        
    }

    //Se crea la función que se encarga de Respawnear al player cuando este pierde todas las vidad, como parametro de la función se pasa una corrutina que se declara mas abajo
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }


    //Ahora se declara la corrutina
    IEnumerator RespawnCoroutine()
    {

        //Cuando se ejecuta, el objeto en este caso el player, se pone como falso en "SetActive", por lo que desaparece
        PlayerController.instance.gameObject.SetActive(false);

        //Despues, se espera durante los segundos que se pongan en la variable "WaitToRespawn"
        yield return new WaitForSeconds(waitToRespawn + (1f / UIController.Instance.fadeSpeed));

        UIController.Instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.Instance.fadeSpeed) + .2f);

        UIController.Instance.FadeFromBlack();

        //Cuando se espera ese tiempo el player se pone de nuevo en true en el "SetActive" y se hace visible
        PlayerController.instance.gameObject.SetActive(true);

        //Cuando se hace visible, el transform, que sería el objeto del player, se cambia de posición, y el destino de este cabio se decide con el checkpoint que esté activo en ese momento.
        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

        //Además, cuando aparece de nuevo, se iguala la vida del jugador con la vida maxima, para así devolverle todas la vidas al reaparecer
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;


        //Por ultimo, después de devolver las vidas, se actualiza el canvas
        UIController.Instance.heart0.sprite = UIController.Instance.healthBar; //Devuelve el cartel de vidas al color normal y quita el rojo
        UIController.Instance.heart1.sprite = UIController.Instance.heartFull; //Añade de nuevo el sprite de Heart1
        UIController.Instance.heart2.sprite = UIController.Instance.heartFull; //Añade de nuevo el sprite de Heart2
        UIController.Instance.heart3.sprite = UIController.Instance.heartFull; //Añade de nuevo el sprite de Heart3
        //Y el vanvas y por ende el interfaz grafica, ya está lista para comenzar el nivel de nuevo

    }

    public void EndLevel()
    { 
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.Instance.levelCompleteImage.SetActive(true);

        UIController.Instance.UpdateCoinCountPause();

        yield return new WaitForSeconds(.1f);

        UIController.Instance.FadeToBlack();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    //Se declara el objeto animator para la bandera del checkpoint, ya que más adelante se cambiará su animación
    public Animator aniFlag;

    //Se declara un valor para el checkpoint = Activo/No activo
    public bool CheckPointState;


    void Start()
    {
        //Cuando comience, buscará el animator activo y lo asignará a la variable de "aniFlag"
        aniFlag = GetComponent<Animator>();
    }


    //Con esta función, deetecta cuando el Player colisiona con el checkPoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Si lo que colisiona con el checkPoint es el Player:
        {
            //Va a llamar a la función de la matriz que desactiva todos los checkpoints
            CheckPointController.instance.DeactiveCheckPoints();
            //Y luego pone activo el ckeckpoint en el que se encuentra
            CheckPointState = true;

            //Cambia la posición de spawn a la del punto en el que esté en ese momento
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }

        /*Por ultimo tras hacer toda la parte lógica, el parametro "CheckPoint" que tiene el animator de "aniFlag" se iguala con CheckPointState, por lo que cuando esté en true,
        Dará paso a la animación de que se activa el checkpoint*/
        aniFlag.SetBool("CheckPoint", CheckPointState);

    }

    //La función que al llamarla se encarga de poner todos los checkpoints en false
    public void ResetCheckPoint()
    {
        CheckPointState = false;
    }

}

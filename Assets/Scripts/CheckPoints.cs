using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    //Se declara el objeto animator para la bandera del checkpoint, ya que m�s adelante se cambiar� su animaci�n
    public Animator aniFlag;

    //Se declara un valor para el checkpoint = Activo/No activo
    public bool CheckPointState;


    void Start()
    {
        //Cuando comience, buscar� el animator activo y lo asignar� a la variable de "aniFlag"
        aniFlag = GetComponent<Animator>();
    }


    //Con esta funci�n, deetecta cuando el Player colisiona con el checkPoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Si lo que colisiona con el checkPoint es el Player:
        {
            //Va a llamar a la funci�n de la matriz que desactiva todos los checkpoints
            CheckPointController.instance.DeactiveCheckPoints();
            //Y luego pone activo el ckeckpoint en el que se encuentra
            CheckPointState = true;

            //Cambia la posici�n de spawn a la del punto en el que est� en ese momento
            CheckPointController.instance.SetSpawnPoint(transform.position);
        }

        /*Por ultimo tras hacer toda la parte l�gica, el parametro "CheckPoint" que tiene el animator de "aniFlag" se iguala con CheckPointState, por lo que cuando est� en true,
        Dar� paso a la animaci�n de que se activa el checkpoint*/
        aniFlag.SetBool("CheckPoint", CheckPointState);

    }

    //La funci�n que al llamarla se encarga de poner todos los checkpoints en false
    public void ResetCheckPoint()
    {
        CheckPointState = false;
    }

}

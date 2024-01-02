using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    //Se declara la matriz "CheckPoints[]" Que se encargar� de guardar todos los checkpoints del nivel, aunque lo m�s probable es que solo se uno uno por nivel, por si acaso se crea as�.
    public CheckPoints[] checkpoints;

    //Se declara el vector3 que guardar� la posici�n del jugador
    public Vector3 spawnPoint; 

    void Awake()
    {
        instance = this; 
    }

    private void Start()
    {

        //Cuando comience, buscar� cual es el checkpoint m�s reciente que est� activo
        checkpoints = FindObjectsOfType<CheckPoints>();

        //Despu�s, cambiar� los valores del vector3 "spawnPoint" y pondr� la posici�n de ese checkpoint para m�s tarde mover al jugador a ese punto
        spawnPoint = PlayerController.instance.transform.position;
    }



    //Con esta funci�n, la matriz recorre todos los checkpoints y resetea el valor de todos ellos
    public void DeactiveCheckPoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint(); //Resetea el checkpoint de la posicion i
        }
    }

    //Con esta funci�n, se marca cual es la posici�n del nuevo spawn del jugador
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    //Se declara la matriz "CheckPoints[]" Que se encargará de guardar todos los checkpoints del nivel, aunque lo más probable es que solo se uno uno por nivel, por si acaso se crea así.
    public CheckPoints[] checkpoints;

    //Se declara el vector3 que guardará la posición del jugador
    public Vector3 spawnPoint; 

    void Awake()
    {
        instance = this; 
    }

    private void Start()
    {

        //Cuando comience, buscará cual es el checkpoint más reciente que esté activo
        checkpoints = FindObjectsOfType<CheckPoints>();

        //Después, cambiará los valores del vector3 "spawnPoint" y pondrá la posición de ese checkpoint para más tarde mover al jugador a ese punto
        spawnPoint = PlayerController.instance.transform.position;
    }



    //Con esta función, la matriz recorre todos los checkpoints y resetea el valor de todos ellos
    public void DeactiveCheckPoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint(); //Resetea el checkpoint de la posicion i
        }
    }

    //Con esta función, se marca cual es la posición del nuevo spawn del jugador
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}

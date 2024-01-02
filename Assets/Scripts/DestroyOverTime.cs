using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    //Declaramos la variable que se encarga de marcar el tiempo de vida del objeto
    public float lifeTime;

    void Update()
    {
        //Cuando se ejecute este script, destruir� el objeto, una vez haya terminado el segundo parametro "lifeTime", que es el tiempo que pongamos en unity en "LifeTime"
        Destroy(gameObject, lifeTime); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Con esta variable transform, podemos hacer referencia a un objeto en unity, en este caso ser� el player
    public Transform target;

    //Con estas variables, especificamos los dos valores que puede tener la c�mara, tanto el minimo como el m�ximo que podr� moverse.
    public float minHeight, maxHeight; 


    //De momento en Start no habr� nada, por que no hay nada que tenga que ocurrir al empezar la escena
    void Start()
    {
        
    }

    void Update()
    {
        /*Esta linea se encarga de decir a la c�mara con este vector3 como debe moverse, en el eje x(Horizontal); seguir al target(Player),
        y en el eje y(Vertical); Seguir al player, pero clampeado con dos valores, el maximo y minimo que puede subir o bajar. La posici�n en z no la modifica*/
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
    }
}

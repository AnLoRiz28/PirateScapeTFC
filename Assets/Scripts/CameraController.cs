using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Se declara la instancia
    public static CameraController instance;

    //Con esta variable transform, podemos hacer referencia a un objeto en unity, en este caso ser� el player
    public Transform target;
    public Transform farBackground;

    //Con estas viariables guardamos la ultima posici�n tanto de x como y para luego usarla y darsela al Fondo
    private float lastXPos, lastYPos;
    
    //Con estas variables, especificamos los dos valores que puede tener la c�mara, tanto el minimo como el m�ximo que podr� moverse.
    public float minHeight, maxHeight;

    //Declaramos la variable para que deje de seguir al usuario
    public bool stopFollow;


    //Awake para la instancia
    private void Awake()
    {
        instance = this;
    }

    //Cada vez que se abra la clase, pondr� los valores del fondo como valores de las dos variables x, y
    void Start()
    {
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    //Siempre que la clase est�e activa se ejecutar� el c�digo de Update()
    void Update()
    {
        //Si la camara est� siguiendo al usuario, puesto que es distinto de !stopFollow
        if (!stopFollow)
        {
            /*Esta linea se encarga de decir a la c�mara con este vector3 como debe moverse, en el eje x(Horizontal); seguir al target(Player),
              y en el eje y(Vertical); Seguir al player, pero clampeado con dos valores, el maximo y minimo que puede subir o bajar. La posici�n en z no la modifica*/
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            //Hace que el fondo vaya siguiendo al player cogiendo su posicion x,y en todo momento
            float amountToMoveX = transform.position.x - lastXPos;
            float amountToMoveY = transform.position.y - lastYPos;
            farBackground.position = farBackground.position + new Vector3(amountToMoveX, amountToMoveY, 0f);

            //Devuelve los valores del transform, en este caso el fondo
            lastXPos = transform.position.x;
            lastYPos = transform.position.y;
        }
        
    }
}

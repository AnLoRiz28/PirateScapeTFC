using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{

    //Se declaran todas las variables que se usarán en la clase
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer theSR;

    public float distanceToAtackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    public float waitAfterAttack;
    private float attackCounter;


    private void Start()
    {
        //Cuando comience la clase, va a recorrer todos los puntos y les va a quitar el parent, para que no se muevan con el objeto padre
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    private void Update()
    {

        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            //Con este if, si detecta al jugador, cambiará el target hacia el que se mueve por el player
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAtackPlayer)
            {
                attackTarget = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                //Cambiará el dentino de movimiento por los puntos que hemos puesto antteriormente
                if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f)
                {
                    currentPoint++;

                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }

                //Cuando haya movimienro hacia la derecha (position menor que el currenPoint), el flip en X se activa para cambiar el flip del enemigo
                if (transform.position.x < points[currentPoint].position.x)
                {
                    theSR.flipX = true;
                }
                //else, cuando haya movimienro hacia la izquierda (position mayor que el currenPoint), el flip en X se desactiva para NO cambiar el flip del enemigo
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    theSR.flipX = false;
                }
            }
            else
            {
                //Atacando al jugador
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }
                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }

        
    }
}

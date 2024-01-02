using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour
{

    //Se declaran las variables que se usan en la clase
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;

    public float moveTime, waitTime;
    private float moveCount, waitCount;


    void Start()
    {
        //Se dan valor a las variables del rigidbody y animator
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        /*e quita el parent de estos dos objetos, para que cuando el enemigo se mueva hacia los lados, estos objetos se queden en su sitio
        Ya que es su punto de referncia de donde deben caminar*/
        leftPoint.parent = null; rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Función Update, se ejecuta en todo momento
    void Update()
    {
        if(moveCount > 0)
        {

            moveCount -= Time.deltaTime;
            if (movingRight) //Si es true que se mueve a la derecha hace lo siguiente:
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y); //Mueve al rb en el eje x con la variable moveSpeed

                theSR.flipX = false; //El Sprite renderer se pone en false el flipX, ya que no rota 

                if (transform.position.x > rightPoint.position.x) //Si llega al punto de la derecha hace lo siguiente:
                {
                    movingRight = false; //Pone en false el movingRight
                }
            }
            else //En el otro casi hace lo contarrio, lo mismo que el anterior, pero se mueve hacia la izquierda
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y); //Mueve el rb con fuerza negativa al moveSpeedm ya que eso es hacia la izquierda

                theSR.flipX = true; //En este caso es true el flip, ya que hay que rotar el sprite del enemigo

                if (transform.position.x < leftPoint.position.x) //Y cuando llegue al punto de izquierda:
                {
                    movingRight = true;//Se pone en true el movingRight, por lo que se repetiria el primer caso del if
                }
            }

            //Con esto hacemos que el enemigo espere
            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f); //Y con esta linea hacemos que sea un tiempo random entre 0.75 y 1.25
            }

            //Con esto damos valor a un parametro del animador, que hace que al andar el enemigo se active la animación de andar
            anim.SetBool("isMoving", true);

            //Hace lo contarrio del caso superior a este
        }else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * 1.25f);
            }
            anim.SetBool("isMoving", false); //Con esta linea desactivamos el parametro para que la animacion de andar se desactive cuando se quede quieto
        }
        
    }
}

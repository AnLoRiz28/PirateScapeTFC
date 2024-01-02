using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    //Variables de Movimiento
    public float moveSpeed;

    //Variables de Componentes de Unity
    public Rigidbody2D rbPlayer;

    //Variables de Salto
    public float jumpForce;
    private bool canDoubleJump;

    public float bounceForce;

    //Variables de Deteccion de suelo
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool isGrounded;

    //Variables de Animaciones del jugador
    public Animator aniPlayer;
    public SpriteRenderer theSR;

    //Variables de la mec�nica de KnockBack
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public bool stopInput;

    private EntradasMovimiento entradasMovimiento;


    private void Awake()
    {
            instance = this;
            entradasMovimiento = new EntradasMovimiento();
    }

    private void OnEnable()
    {
        entradasMovimiento.Enable();
    }

    private void OnDisable()
    {
        entradasMovimiento.Disable();
    }

    void Start()
    {
        //Al empezar, buscar� los componentes del animator de las dos variables.
        aniPlayer = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();

        //Quitar la linea de debajo de comentarios para borrar los datos del playerPrefs de los niveles, luego ponerla de nuevo en comentarios
        //PlayerPrefs.DeleteKey("NivelesDesbloqueados");
    }

    void Update()
    {
        if (!PauseMenu.instance.isPaused && !stopInput) //Todo el movimiento del player solo ocurrir� se el Menu de pausa se encuentra desactivado
        {
            //Solo podremos mover al personaje cuando el knockback haya llegado a 0 y haya terminado, para as� no poder movernos mientras este se realiza.
            if (knockBackCounter <= 0)
            {
                //Cuando se pulsen las teclas de "Horizontal"(Que est�n especificadas en el Input Manager), el player, se mover� horizontalmente, ya que actua sobre es el ejeX 
                rbPlayer.velocity = new Vector2(moveSpeed * entradasMovimiento.Movimiento.Horizontal.ReadValue<float>(), rbPlayer.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround); //Crea un circulo debajo del objeto para detectar el suelo

                //Si est� activo "isGrounded" y por lo tanto el player est� en el suelo, se podr� realizar un doble salto es decir saltar despu�s del primer salto
                if (isGrounded)
                {
                    canDoubleJump = true;

                }

                //Si la tecla "Jump" del Input Manager se pulsa, ocurre:
                if (entradasMovimiento.Movimiento.Salto.ReadValue<float>() >= 1)
                {
                    //Si se detecta que el jugador est� en el suelo
                    if (isGrounded)
                    {
                        //Igual que anteriormente modificaba el ejeX, ahora modifica el ejeY(Vertical) y aplica la variable JumpForce para ajustar cuanto se mueve el player hacia arriba
                        rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
                        AudioManager.instance.PlaySoundFX(14);
                    }
                    else
                    {
                        //Adem�s si el canDoubleJump es true, quiere decir que est� en el suelo:
                        if (canDoubleJump)
                        {
                            //Dejar� hacer un segundo salto de la misma forma que el anterior
                            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
                            AudioManager.instance.PlaySoundFX(14);

                            canDoubleJump = false; //Despu�s de eso, la variable se pondr� en false, hasta que se vuelva a tocar el suelo.
                        }
                    }


                }

                //Con esto, el player puede moverse hac�a el lado contrario al que mira el sprite y este se girar� usando el flip sobre el sprite renderer del jugador
                if (rbPlayer.velocity.x < 0)
                {
                    theSR.flipX = true;
                }
                else if (rbPlayer.velocity.x > 0)
                {
                    theSR.flipX = false;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime; //Esta linea se encarga de bajar el contador del knockback a 0 usando el deltaTime

                //Verifica en que posici�n est� el sprite renderer y hace que el movimiento del knockbac sea acorde a es aposici�n
                if (!theSR.flipX)
                {
                    //Si el player est� mirando hacia la derecha aplica la fuerza en negativo
                    rbPlayer.velocity = new Vector2(-knockBackForce, rbPlayer.velocity.y);
                }
                else
                {
                    //Si es el caso opuesto, aplica la fuerza en negativo
                    rbPlayer.velocity = new Vector2(knockBackForce, rbPlayer.velocity.y);
                }
            }
        }
       
       
        //Hace referencia a las variables que se han creado en el animator, para dar paso a la animaci�n de caminar si se mueve la variable "moveSpeed"
        aniPlayer.SetFloat("moveSpeed", Mathf.Abs(rbPlayer.velocity.x));
        //O dar paso a la animaci�n de salto si cambia a true o false la variable "isGrounded"
        aniPlayer.SetBool("isGrounded", isGrounded);
    }

    public void Knockback()
    {
        knockBackCounter = knockBackLength; //Le da el valor al counter que tiene el Lenght
        rbPlayer.velocity = new Vector2(4f, knockBackForce); //El player reacciona moviendo el ejeY(vertical) y el ejeX(Horizontal) se mueve con 4f siempre
    }

    //Esta funci�n hace que el jugador mueve su eje y con la fuerza que se indique en bounceForce, se llama a esta funci�n al matar a un enemigo en "hurtBox"
    public void Bounce()
    {
        rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, bounceForce);
    }
}

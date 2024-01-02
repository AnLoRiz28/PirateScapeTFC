using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICanvasMenus : MonoBehaviour
{
    //Se declara como estancia para poder usar las funciones de este fichero fuera de el
    public static UICanvasMenus Instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Cada vez que comienza:
        StartCoroutine(CoFadeScreen());
    }

    void Update()
    {
        if (shouldFadeToBlack)
        {
            //Cambia la opacidad del fadeScreen y lo pone en 1f
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f) //Si está en 1f:
            {
                shouldFadeToBlack = false; //Lo pone en falso para no hacerlo de nuevo
            }
        }

        //Hace lo contrario al anterior, pero poniendo la opacidad en 0 (Transparente)
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    //Se crean las dos funciones que se encargan de poner la pantalla en negro con un fundido y de quitar ese fundido negro
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void CambiarEscena(string nombre)
    {
        //StartCoroutine(CoToFadeScreen(nombre));
        SceneManager.LoadScene(nombre); //Se pasa como parametro el nombre de la escena
    }

    public IEnumerator CoFadeScreen()
    {
        yield return new WaitForSeconds(.5f); //Espera durante 1f
        FadeFromBlack();
    }

    public IEnumerator CoToFadeScreen()
    {
        FadeToBlack();
        yield return new WaitForSeconds(2f); //Espera durante 1f
        

    }
}

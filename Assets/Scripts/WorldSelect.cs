using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelect : MonoBehaviour
{

    //=================================================================================
    //=================================================================================
    //====================== Esta clase no se usa en el juego =========================
    //=================================================================================
    //=================================================================================

    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}

//No borro la clase de momento por si hay algfuna dependecian a esta en alguna otra clase o parametro

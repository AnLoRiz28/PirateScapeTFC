using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoIsla : MonoBehaviour
{

    //=================================================================================
    //=================================================================================
    //====================== Esta clase no se usa en el juego =========================
    //=================================================================================
    //=================================================================================



    public static DesbloqueoIsla instance;

    public bool IslaDesbloqueada;

    private void Awake()
    {
        instance = this;
    }


    //Fución que detecta cuando algo colisiona con el colider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Si lo que colisiona es el player
        {
            IslaDesbloqueada = true;
        }
    }
}

//No borro la clase de momento por si hay algfuna dependecian a esta en alguna otra clase o parametro

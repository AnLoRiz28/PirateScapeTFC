using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueoIsla : MonoBehaviour
{
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

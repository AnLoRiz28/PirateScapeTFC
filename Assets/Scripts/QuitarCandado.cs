using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarCandado : MonoBehaviour
{

    //=================================================================================
    //=================================================================================
    //====================== Esta clase no se usa en el juego =========================
    //=================================================================================
    //=================================================================================

    public GameObject candado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DesbloqueoIsla.instance.IslaDesbloqueada == true)
        {
            candado.SetActive(false);
        }
        else
        {

        }
    }

}
//No borro la clase de momento por si hay algfuna dependecian a esta en alguna otra clase o parametro

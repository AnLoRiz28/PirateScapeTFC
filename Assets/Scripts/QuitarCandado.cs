using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarCandado : MonoBehaviour
{

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

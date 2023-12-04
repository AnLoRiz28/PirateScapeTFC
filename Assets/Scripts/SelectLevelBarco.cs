using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelBarco : MonoBehaviour
{
    public static SelectLevelBarco Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }



}

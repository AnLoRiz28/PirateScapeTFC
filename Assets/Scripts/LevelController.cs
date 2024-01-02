using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    
    public static LevelController instance;

    //Se declaran las variables que se usarán
    public Button[] LevelButtons;
    public int UnlockedLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (LevelButtons.Length > 0)
        {
            for (int i = 0; i < LevelButtons.Length; i++) //Este for recorrerá toda la lista
            {
                LevelButtons[i].interactable = false;//Desactivará todos los botones
            }

            for (int i = 0; i < PlayerPrefs.GetInt("NivelesDesbloqueados", 1); i++)
            {
                LevelButtons[i].interactable = true; //Activará solo el botón que se indique en la variable en unity
            }
        }
    }

    public void SubirNiveles() //La función se encarga de ir subiendo los niveles a medida que se terminan y estos datos se guardan en PlayerPrefs,
                               //para que los datos no se borren al cerrar la aplicación
    {
        if (UnlockedLevel > PlayerPrefs.GetInt("NivelesDesbloqueados",1))
        {
            PlayerPrefs.SetInt("NivelesDesbloqueados", UnlockedLevel);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
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
            for (int i = 0; i < LevelButtons.Length; i++)
            {
                LevelButtons[i].interactable = false;
            }

            for (int i = 0; i < PlayerPrefs.GetInt("NivelesDesbloqueados", 1); i++)
            {
                LevelButtons[i].interactable = true;
            }
        }
    }

    public void SubirNiveles()
    {
        if (UnlockedLevel > PlayerPrefs.GetInt("NivelesDesbloqueados",1))
        {
            PlayerPrefs.SetInt("NivelesDesbloqueados", UnlockedLevel);
        }
    }
}

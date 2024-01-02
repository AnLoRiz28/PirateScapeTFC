using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Lo hacemos instancia, para poder usar las funciones de esta clase en otros scripts
    public static AudioManager instance;

    //Variables para las funciones de Audio
    public AudioSource[] soundEffects;//Al hacerlo de esta manera, podemos asignar una lista de audios al AudioSource

    public AudioSource bgMusic, VictoryMusic;
   

    //Funci�n Awake para la instancia
    private void Awake()
    {
        instance = this;
    }

    //Start y Update est�n vacios,  ya que esta clase no hace nada por si sola, solo cuando llamas a sus funciones
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //Esta funci�n se encarga de pasar como parametro un numero que equivaldr�a a uno de la lista anterior y con .play() activaria ese sonido
    public void PlaySoundFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }


    //Funciona igual que el PlaySoundFX(), pero en lugar de repoducir sonido, con .Stop() deja de reproducirlo
    public void StopSoundFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject deathEffectPirata;

    //La clase se activa cuando se colisiona
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") //Revisa que sea una colision contra un enemigo
        {
            other.transform.parent.gameObject.SetActive(false); //Desactiva el GameObject del enemigo
            PlayerController.instance.Bounce(); //Da un salto al jugador -> Esta función está en otra clase

            Instantiate(deathEffectPirata, other.transform.position, other.transform.rotation); //Reproduce la animación que hemos declarado arriba en la posicion del transform del enemigo

            AudioManager.instance.PlaySoundFX(3); //Reproduce el efecto de sunido 3 de la lista
        }
    }
}

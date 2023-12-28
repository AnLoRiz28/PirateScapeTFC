using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject deathEffectPirata;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            PlayerController.instance.Bounce();

            Instantiate(deathEffectPirata, other.transform.position, other.transform.rotation);
        }
    }
}

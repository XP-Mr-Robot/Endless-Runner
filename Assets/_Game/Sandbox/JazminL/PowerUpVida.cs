using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Vida health = FindObjectOfType<Vida>();
        health.MasUno();

    }

}

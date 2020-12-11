using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVida : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Vida health = FindObjectOfType<Vida>();
        health.hpUP();
        Destroy(this.gameObject);

    }

}

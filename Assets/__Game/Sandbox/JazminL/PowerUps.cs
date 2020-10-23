using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject vida;
    public float MasUno = 1f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    public void PickUp(Collider player)
    {
        Instantiate(vida, transform.position, transform.rotation);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health += MasUno;


            

    }


}

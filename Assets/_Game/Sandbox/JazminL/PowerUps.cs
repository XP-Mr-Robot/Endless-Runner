using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //Powerup-Vida
    public GameObject vida;
    public float MasUno = 1f;


    //Powerup-Iman
    


    //Powerup-Skateboard
    bool isInvincible;

    void Start()
    {
        StartCoroutine(Coroutine());
    }

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

    //
    public void Damage(int daño)
    {
        if(isInvincible)
        {
            daño = 0;
        }
        else
        {
            //
            PlayerStats stats = GetComponent<PlayerStats>();
            stats.health -= daño;

        }
    }

 
    private IEnumerator Coroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(7f);
        isInvincible = false;

    }

}

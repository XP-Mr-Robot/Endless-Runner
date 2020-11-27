using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidas = 3;
    int lastCollision;
    public GameObject Fail;
    CharacterController controller;
    Collider m_Collider;
    void Start()
    {
        m_Collider = GetComponent<Collider>();

        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        Death();
    }
   

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
          switch (hit.gameObject.tag)
           {
               case "obstaculo":
                if (lastCollision != hit.gameObject.GetInstanceID())
                    TakeDamage();
                lastCollision = hit.gameObject.GetInstanceID();
                break;


           }
        

    }

    private void TakeDamage()
    {
        vidas -= 1;
        Debug.Log("Collider.enabled = " + m_Collider.enabled);
        GameObject.Find("HP").GetComponent<HP_Counter>().hpCounter-=1;
        Debug.Log("tienes " + vidas + " vidas");
        if (vidas <= 0)
        {
            Debug.Log("Game over");
            Fail.SetActive(true);
            Destroy(gameObject);
        }


    }

    private void Death()
    {
        if(this.transform.position.y<(-3))

        {
            Debug.Log("MUERTE");
            Fail.SetActive(true);
            Destroy(gameObject);

        }
    }

   




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    Animator anim;

    public AudioClip audioMuerte;
    public AudioClip audioDaño;
    public int vidas = 3;
    int lastCollision;
    public GameObject Fail;
    CharacterController controller;
    Collider m_Collider;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

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
                {
                    TakeDamage();

                    anim.SetTrigger("Damage");
                    AudioSource.PlayClipAtPoint(audioDaño, transform.position);
                }
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
            this.controller.enabled = !m_Collider.enabled;
            anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(audioMuerte, transform.position);
            Debug.Log("Game over");
            Fail.SetActive(true);
        }
    

    }
    public void hpUP()
    {
        if(vidas<3)
        {
            vidas += 1;
            GameObject.Find("HP").GetComponent<HP_Counter>().hpCounter += 1;

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

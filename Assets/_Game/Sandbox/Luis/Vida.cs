using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    Animator anim;

    public AudioClip audioMuerte;
    public AudioClip audioDaño;

    public static int vidas = 3;
    int lastCollision;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
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
        Debug.Log("tienes " + vidas + " vidas");
        if (vidas <= 0)
        {
            anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(audioMuerte, transform.position);
            Debug.Log("Game over");
            Destroy(gameObject);
        }
    }



   
}

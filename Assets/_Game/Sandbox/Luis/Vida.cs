using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public static int vidas = 3;
    int lastCollision;
    void Start()
    {
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
                    TakeDamage();
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
            Debug.Log("Game over");
            Destroy(gameObject);
        }
    }



   
}

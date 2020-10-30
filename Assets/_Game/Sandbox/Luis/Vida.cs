using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public static int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "obstaculo":
                vidas -= 1;
                Debug.Log("tienes " + vidas + " vidas");
                if (vidas <= 0)
                {
                    Debug.Log("Game over");
                    Destroy(gameObject);
                }
                break;
        }
        
    }
}

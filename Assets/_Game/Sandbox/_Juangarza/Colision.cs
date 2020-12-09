using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    [SerializeField] private GameObject Particles = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        print("on mouse down! = " + this.GetComponent<Rigidbody>());
        //this.GetComponent<Rigidbody>().AddForce(this.transform.up * 2.0f);
        this.transform.position = new Vector3(0, 2, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
       //Solo usar si es valido
       if (this.Particles != null)
        {
            this.Particles.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.Particles != null)
        {
            this.Particles.SetActive(false);
        }
    }
}

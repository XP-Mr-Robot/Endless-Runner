using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnCollision : MonoBehaviour
{

    [SerializeField] private GameObject m_Particles = null;


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
        //this.GetComponent<Rigidbody>().AddForce( this.transform.up * 2.0f );

        this.transform.position = new Vector3(0, 5, 0);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        // solo usar si es valido
        if (this.m_Particles != null)
        {
            this.m_Particles.SetActive(true);
        }

    }


    private void OnCollisionExit(Collision collision)
    {
        // solo usar si es valido
        if (this.m_Particles != null)
        {
            this.m_Particles.SetActive(false);
        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstancer : MonoBehaviour
{

    [SerializeField] private GameObject m_ringsInstance;

    [SerializeField] private float m_time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateRings",1,m_time);
    }

    // Update is called once per frame
    void InstantiateRings()
    {
        GameObject _rings = Instantiate(m_ringsInstance, transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Counter : MonoBehaviour
{
    [SerializeField] private Text m_Text;
    public int hpCounter = 3;
    void Start()
    {
    }

// Update is called once per frame
void Update()
    {
      
        this.m_Text.text = this.hpCounter.ToString();
    }
}


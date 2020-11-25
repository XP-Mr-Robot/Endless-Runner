using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int numberOfCoins = 0;
    [SerializeField] private Text m_Text = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.m_Text.text = this.numberOfCoins.ToString();
    }
}

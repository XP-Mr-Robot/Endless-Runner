using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinValue : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.m_Text.text = GameObject.Find("TotalScore").GetComponent<TotalScore>().numberOfCoins.ToString();

    }
}

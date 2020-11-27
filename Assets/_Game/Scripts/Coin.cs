using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public Transform playertransform;
    public float moveSpeed = 10f;

    CoinMove move;
    void Start()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        move = gameObject.GetComponent<CoinMove>();
    }

    
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
           // Debug.Log("Coins:" + PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Coin Magnet")
        {
            move.enabled = true;
        }
           
    }
    



}

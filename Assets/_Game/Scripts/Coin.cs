using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool DoublePickUp;
    public int points;

    private void Start()
    {
        points = 1;
    }

    private void Update()
    {
        if (DoublePickUp = true)
        {
            points = 2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if(other.tag == "Player")
        {
          

            GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins += points;
            Debug.Log("Coins:" + GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins);
            GameObject.Find("GameManager").GetComponent<PlayerManager>().coinSound.Play();
            Destroy(gameObject);


        }
    }
    
}

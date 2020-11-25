using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins +=1;
            Debug.Log("Coins:" + GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins);
            GameObject.Find("GameManager").GetComponent<PlayerManager>().coinSound.Play();
            Destroy(gameObject);
        }
    }
    
}

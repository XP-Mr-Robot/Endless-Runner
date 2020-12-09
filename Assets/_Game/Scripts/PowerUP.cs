using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins +=10;
            GameObject.Find("TotalScore").GetComponent<TotalScore>().numberOfCoins += 10;
            Debug.Log("Coins:" + GameObject.Find("Clock").GetComponent<CoinCounter>().numberOfCoins);
            GameObject.Find("GameManager").GetComponent<PlayerManager>().coinSound.Play();
            Destroy(gameObject);
        }
        
           
    }
    



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject coinMagnet;

    // Start is called before the first frame update
    void Start()
    {
        coinMagnet = GameObject.FindGameObjectWithTag("Coin Magnet");
        coinMagnet.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateCoins());
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    IEnumerator ActivateCoins()
    {
        coinMagnet.SetActive(true);
        yield return new WaitForSeconds(7);
        coinMagnet.SetActive(false);
    }
}

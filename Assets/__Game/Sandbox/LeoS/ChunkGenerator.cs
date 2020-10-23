using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] chunks = new GameObject[4];
    private int position = 50;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("HOLA");
        position = position + 100;
        this.transform.position = new Vector3(0, 0, position);
        GameObject clone = (GameObject)Instantiate(chunks[Random.Range(0,3)], new Vector3(0, 0, position+150),Quaternion.identity);
        Destroy(clone, 15.0f);
    }
}

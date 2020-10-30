using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] chunks = new GameObject[4];
    private int position = 50;
    private int spawn = 400;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

      
        position = position + 100;
        this.transform.position = new Vector3(0, 0, position);
        GameObject clone = (GameObject)Instantiate(chunks[Random.Range(0,chunks.Length)], new Vector3(0, 0, spawn),Quaternion.identity);
        spawn = spawn + 100;

        Destroy(clone, 15.0f);
    }
}

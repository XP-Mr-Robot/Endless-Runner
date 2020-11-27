using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUps : MonoBehaviour
{
    public List<GameObject> powerUps;
    public int[] table = {25, 25, 25, 25};

    public int total;
    public int randomNumber;
    public float rotationspeed;
    private void Start()
    {
        foreach(var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                powerUps[i].SetActive(true);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
    private void Update()
    {
        //Quaternion
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, rotationspeed * Time.deltaTime, 0f));
    }
}
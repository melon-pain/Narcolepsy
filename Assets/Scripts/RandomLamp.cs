using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLamp : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnList;
    // Start is called before the first frame update
    void Start()
    {
        int randIndex = Random.Range(0, spawnList.Length);

        for (int i = 0; i < spawnList.Length; i++)
        {
            if(i != randIndex)
            {
                spawnList[i].GetComponent<Lamp>().Fix();
            }
        }
    }
}

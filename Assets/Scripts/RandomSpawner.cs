using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnList;
    [SerializeField] private int numToSpawn = 0; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnList.Length; i++)
        {
            spawnList[i].SetActive(false);
        }

        int numSpawned = 0;
        while(numSpawned < numToSpawn)
        {
            int randIndex = Random.Range(0, spawnList.Length);
            if (!spawnList[randIndex].activeSelf)
            {
                spawnList[randIndex].SetActive(true);
                numSpawned++;
            }
        }
    }
}

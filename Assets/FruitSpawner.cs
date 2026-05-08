using UnityEngine;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    public List<GameObject> fruitPrefabs; 

    void Start()
    {
        Application.targetFrameRate = 60; 
        Time.timeScale = 1f; 
        SpawnFruit();
    }

    public void SpawnFruit()
    {
        fruitcon[] allFruits = FindObjectsOfType<fruitcon>();
        bool isAnyoneWaiting = false;

        foreach (fruitcon f in allFruits)
        {
            if (!f.isDropped)
            {
                isAnyoneWaiting = true;
                break;
            }
        }

        if (!isAnyoneWaiting)
        {
            int randomIndex = Random.Range(0, 4);
            Instantiate(fruitPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
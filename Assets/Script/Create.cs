using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject EatenThings; 
    public float minX = -10f; 
    public float maxX = 10f;
    public float minY=-5f; 
    public float maxY = 5f;
    public float spawnInterval = 3f;
    private float timer = 0f;
    public bool canIns = false; 

    void Update()
    {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnObjectWithinRange();
                timer = 0f;
            }
        
    }
    void SpawnObjectWithinRange()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(EatenThings, spawnPosition, Quaternion.identity);
    }

    void Start()
    {
        
    }

    // Update is called once per frame

}


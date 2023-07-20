using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float movementSpeed = 2f; // Speed at which the enemy moves towards the player
    public Gamem gm;

    public string playerTag = "Player"; 

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found with tag: " + playerTag);
        }
    }
    public void findPlayerTag()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        // Calculate the direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the player character
        if (other.CompareTag("Player"))
        {
            gm.playerGameObjects.Remove(other.gameObject);
            if (gm.playerGameObjects.Count >= 1)
            {
                if (gm.countNum >= gm.playerGameObjects.Count)
                {
                    gm.countNum = gm.countNum - gm.playerGameObjects.Count;
                    
                }
                gm.SwitchBetweenPlayer();
            }
            
            
            // Destroy the player character
            Destroy(other.gameObject);
            findPlayerTag();


        }
    }



   
    

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bug : MonoBehaviour
{
    public float enemySize = 1f; // Size of the enemy
    public float movementSpeed = 5f; // Speed at which the enemy moves towards the player

    private GameObject playerCharacter; // Reference to the player character

    private void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerCharacter == null)
            return;

        // Calculate the direction towards the player
        Vector3 direction = playerCharacter.transform.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player character
        if (other.CompareTag("Player"))
        {
            float playerSize = other.GetComponent<PlayerSize>().currentSize;

            // Compare sizes to determine outcome
            if (playerSize < enemySize)
            {
                // Player is smaller, destroy the player
                Destroy(other.gameObject);
            }
            else
            {
                // Player is larger, destroy the enemy
                Destroy(gameObject);
            }
        }
    }
}

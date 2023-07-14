using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float movementSpeed = 2f; // Speed at which the enemy moves towards the player

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

    private void Update()
    {
        // Calculate the direction towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player character
        if (other.CompareTag("Player"))
        {
            // Destroy the player character
            Destroy(other.gameObject);
        }
    }



    void OnTriggerEnter2D(Collider2D cd)
    {
        // Check if the collided object is the player character
        if (cd.gameObject.CompareTag("Player") || cd.gameObject.CompareTag("PlayerSplit"))
        {
            // Destroy the game object
            Destroy(cd.gameObject);
        }
    }

}
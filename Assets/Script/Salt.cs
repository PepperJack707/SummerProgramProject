using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamem gm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.playerGameObjects.Remove(collision.gameObject);
            if (gm.playerGameObjects.Count >= 1)
            {
                if (gm.countNum >= gm.playerGameObjects.Count)
                {
                    gm.countNum = gm.countNum - gm.playerGameObjects.Count;

                }
                gm.SwitchBetweenPlayer();
            }


            // Destroy the player character
            Destroy(collision.gameObject);



        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

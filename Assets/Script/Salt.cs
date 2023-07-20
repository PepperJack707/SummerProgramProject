using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamem gm;
    public GameObject dead;
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
                Destroy(collision.gameObject);
            }

            else
            {
                dead.SetActive(true);
                SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
               

            }

        }
        else
        {
            
            Destroy(collision.gameObject);

        }
    }
}

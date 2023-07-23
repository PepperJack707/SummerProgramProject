using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamem gm;
    public GameObject dead;
    public GameObject button;
    public Collider2D salt;
    public bool isDeadly;
    void Start()
    {
        salt = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDeadly == true)
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
                for (int i = 0; i < collision.transform.childCount; i++)
                {
                    Transform child = collision.transform.GetChild(i);
                    child.gameObject.SetActive(false);
                }


            }

        }
        else if(collision.CompareTag("Stick") && isDeadly == true)
        {
            isDeadly = false;
            print("not deadly");
        }
        else if(collision.CompareTag("Bug"))
        {
            button.SetActive(true);
            Destroy(collision.gameObject);


        }
    }

    public void OnTriggerExit2D(Collider2D cn)
    {
        if(cn.tag == "Stick")
        {
            isDeadly = true;
        }
    }


}

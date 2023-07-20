using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Replicate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    //public Animator walking;
    public Enemy en;
    public GameMana gm;
    public Animator split;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SplitFunction();
    }
    void SplitFunction()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {

            StartCoroutine(SplitCoroutine());
        }

    }
    IEnumerator SplitCoroutine()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Transform child = playerObject.transform.GetChild(0);
        SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerSpriteRenderer.enabled = false;

        child.gameObject.SetActive(true);
        print("Replicate");
        yield return new WaitForSeconds(1f);


        child.gameObject.SetActive(false);
        playerSpriteRenderer.enabled = true;

        // Calculate the position for the new player object
        Vector3 currentPosition = playerObject.transform.position;
        currentPosition.y += -0.07f;

        // Calculate the scale for the new player object
        Vector3 currentScale = playerObject.transform.localScale;
        Vector3 smallerScale = currentScale * 0.8f;

        // Get the width of the playerObject sprite
        float playerObjectWidth = playerSpriteRenderer.bounds.size.x;

        // Get the width of the player1 object sprite
        float player1Width = playerPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        // Calculate the distance to keep between the objects
        float distance = (playerObjectWidth + player1Width)*1.0f;

        // Instantiate the new player object next to the playerObject
        GameObject player1 = Instantiate(playerPrefab, currentPosition + new Vector3(distance, 0f, 0f), Quaternion.identity);

        // Set the scale of the new player object
        player1.transform.localScale = smallerScale;


        player1.tag = "PlayerSub";
        gm.playerGameObjects.Add(player1);
        print("Replicate tag: " + player1.tag);
        player1.transform.localScale = smallerScale;
        playerObject.transform.localScale = smallerScale;
        currentPosition.x += -0.1f;
        
        playerObject.transform.position = currentPosition;

        en.player = player1.transform;
        gm.haveNewObj(player1);
       // gm.SwitchBetweenPlayer();
    }
}

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
    public Gamem gm;
    public Animator split;
    public int NumOfSPlit;
    
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
            
            if (NumOfSPlit < 3)
            {
                StartCoroutine(SplitCoroutine());
            }
                
        }
        

    }
    IEnumerator SplitCoroutine()
    {
        NumOfSPlit++;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Transform child = playerObject.transform.GetChild(0);
        SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        playerSpriteRenderer.enabled = false;

        child.gameObject.SetActive(true);
        print("Replicate");
        yield return new WaitForSeconds(1f);


        child.gameObject.SetActive(false);
        playerSpriteRenderer.enabled = true;

        Vector3 currentPosition = playerObject.transform.position;
        currentPosition.y += -0.07f;
        Vector3 currentScale = playerObject.transform.localScale;
        Vector3 smallerScale = currentScale * 0.8f;

        float playerObjectWidth = playerSpriteRenderer.bounds.size.x;
        float player1Width = playerPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float distance = (playerObjectWidth + player1Width)*1.0f;
        GameObject player1 = Instantiate(playerPrefab, currentPosition + new Vector3(distance, 0f, 0f), Quaternion.identity);
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

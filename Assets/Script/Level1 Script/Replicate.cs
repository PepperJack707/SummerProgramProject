using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Replicate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject playerSplitPrefab;
    //public Animator walking;
    public Enemy en;
    public PlayerMove pm;
    public Gamem gm;
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
        //playerObject.transform.localScale = playerObject.transform.localScale * 0.8f;
        //child.transform.localScale = child.transform.localScale * 1.25f;
        print("Replicate");
        //split.SetBool("IsSplitting", true);
        yield return new WaitForSeconds(1f);

        //split.SetBool("IsSplitting", false);

       
        child.gameObject.SetActive(false);
        playerSpriteRenderer.enabled = true;


        Vector3 currentPosition = playerObject.transform.position;
        currentPosition.y += -0.07f;
        Vector3 currentScale = playerObject.transform.localScale;


        Vector3 smallerScale = currentScale *0.8f;

        float offset = 1.5f;

        GameObject player1 = Instantiate(playerPrefab, currentPosition + new Vector3(offset, 0f, 0f), Quaternion.identity);
        
       
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

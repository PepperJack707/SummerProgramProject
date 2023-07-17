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
        print("Replicate");
        //walking.SetBool("Split", true);
        yield return new WaitForSeconds(0f);

        //walking.SetBool("Split", false);

        SpriteRenderer spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();

        Vector3 currentPosition = pm.playerPosition;
        Vector3 currentScale = pm.playerScale;

        Vector3 smallerScale = currentScale;
        float offset = 1.3f;

        GameObject player1 = Instantiate(playerPrefab, currentPosition + new Vector3(offset, 0f, 0f), Quaternion.identity);
        gm.playerGameObjects.Add(player1);

        player1.transform.localScale = smallerScale;
        en.player = player1.transform;
        gm.SwitchBetweenPlayer();
    }
}

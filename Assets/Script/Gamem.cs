using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gamem : MonoBehaviour
{
    public Dictionary<GameObject, bool> players = new Dictionary<GameObject, bool>();
    public ArrayList playerGameObjects = new ArrayList();
    int countNum ;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (!players.ContainsKey(playerObject))
            {
                players.Add(playerObject, false);
                playerGameObjects.Add(playerObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(players.Count);
        if(Input.GetKeyDown("p"))
        {
            print("is runnin");
            SwitchBetweenPlayer();
        }
    }

    public void SwitchBetweenPlayer()
    {
        print("current count: " + countNum);
        if (countNum == 0)
        {
            GameObject previousPlayerObject = (GameObject)playerGameObjects[playerGameObjects.Count-1];
            PlayerMove previousScript = previousPlayerObject.GetComponent<PlayerMove>();
            previousScript.GotoSleep();
            previousScript.enabled = false;
            print("disabled");
            
        }
        else
        {
            GameObject previousPlayerObject = (GameObject)playerGameObjects[countNum - 1];
            PlayerMove previousScript = previousPlayerObject.GetComponent<PlayerMove>();
            previousScript.GotoSleep();
            previousScript.enabled = false;
            print("disabled");
        }

        GameObject currentPlayerObject = (GameObject)playerGameObjects[countNum];
        PlayerMove currentScript = currentPlayerObject.GetComponent<PlayerMove>();

        if (currentScript != null)
        {
            currentScript.enabled = true;
            currentScript.WakeUp();
        }

        countNum++;
        if (countNum >= playerGameObjects.Count)
        {
            countNum = 0;
        }
        print("num of obj: " + playerGameObjects.Count);
       

        //print(players[currentPlayerObject]);
    }

  public void haveNewObj(GameObject gameobj)
    {
        PlayerMove previousScript = gameobj.GetComponent<PlayerMove>();
        previousScript.GotoSleep();
        previousScript.enabled = false;
    }
}

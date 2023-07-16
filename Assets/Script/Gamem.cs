using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamem : MonoBehaviour
{
    public Dictionary<GameObject, bool> players = new Dictionary<GameObject, bool>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (!players.ContainsKey(playerObject))
            {
                players.Add(playerObject, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(players.Count);
    }
}

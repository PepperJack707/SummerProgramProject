using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    // Start is called before the first frame update
    public DetectHIt detectH;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "Player" || cd.tag == "PlayerSplit")
        {
            detectH.objectHit++;
            print(detectH.objectHit);
            Destroy(gameObject);
           if(detectH.objectHit ==3)
            {
                detectH.SetcActive();
            }
            
            
        }
        //detectH.objectHit = 0;
    }
}

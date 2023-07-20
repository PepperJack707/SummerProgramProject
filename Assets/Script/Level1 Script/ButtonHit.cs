using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    // Start is called before the first frame update
    public DetectHIt detectH;
    public GameObject nextButton;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "Player")
        {
            detectH.turnButtonOn(nextButton);
            print(detectH.objectHit);
            //Destroy(gameObject);

        }
    }
    void OnTriggerExit2D(Collider2D cd)
    {
        print("leaving");
        if(nextButton.tag == "Button3")
        {
            print("destroyed all");
            detectH.destroyAllGameObj();
        }
        else
        {
            detectH.turnButtonOff(nextButton);
        }
        

    }
}

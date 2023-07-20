using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHIt : MonoBehaviour
{
    public GameObject create; 
    public int objectHit;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void SetcActive()
    {
        create.SetActive(true);
    }
    public void turnButtonOn(GameObject button)
    {
        button.SetActive(true);
    }
    public void turnButtonOff(GameObject button)
    {
        button.SetActive(false);
    }
    public void destroyAllGameObj()
    {
        Destroy(button1);
        Destroy(button2);
        Destroy(button3);
    }
}

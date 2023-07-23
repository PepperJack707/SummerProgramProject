using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMTut2 : MonoBehaviour
{
    public Enemy en;
    public Collider2D cd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnEnOn()
    {
        en.enabled = true;
        cd.enabled = true;
    }
}

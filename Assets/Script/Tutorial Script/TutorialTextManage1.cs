using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextManage1 : MonoBehaviour
{
    public GameObject rep;
    public ButtonHit bh;
    public Collider2D cd;
    public PlayerMove pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnRepOn()
    {
        rep.SetActive(true);
    }

    public void turnButtonScriptOn()
    {
        bh.enabled = true;
        cd.enabled = true;
    }

    public void turnPlayerMove()
    {
        pm.enabled = true;

    }


}

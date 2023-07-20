using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Rigidbody2D rd;
    public float speed =1f;
    public Sprite facingLeft;
    public SpriteRenderer sr;
    public Sprite facingRight;
    public Sprite facingDown;
    public Sprite facingUp;
    public Animator walking;
    private bool isClick;
    private int count;
    public GameObject playerPrefab;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        WakeUp();
        

    }


    // Update is called once per frame
    void Update()
    {
        DetectPlayerMove();
        
        //growFunction();
      
        
    }


    public void DetectPlayerMove()
    {
       
        if (Input.GetKey("w"))
        {
            rd.AddForce(Vector2.up * speed, ForceMode2D.Force);
            sr.sprite = facingUp;
            walking.SetBool("TurnU", true);
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);
            walking.SetBool("TurnL", false);

        }
        else if (Input.GetKey("s"))
        {
            rd.AddForce(Vector2.down * speed , ForceMode2D.Force);
            sr.sprite = facingDown;
            walking.SetBool("TurnD", true);
            walking.SetBool("TurnR", false);
            walking.SetBool("TurnL", false);
            walking.SetBool("TurnU", false);

        }
        else if (Input.GetKey("d"))
        {
            rd.AddForce(Vector2.right * speed, ForceMode2D.Force);
            sr.sprite = facingRight;
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", true);
            walking.SetBool("TurnL", false);
            walking.SetBool("TurnU", false);


        }
        else if (Input.GetKey("a"))
        {
            rd.AddForce(Vector2.left * speed, ForceMode2D.Force);
            sr.sprite = facingLeft;
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);
            walking.SetBool("TurnU", false);
            walking.SetBool("TurnL", true);
        }
        else
        {
            rd.velocity = Vector2.zero; 
            walking.SetBool("TurnD", false);
            walking.SetBool("TurnR", false);
            walking.SetBool("TurnL", false);
            walking.SetBool("TurnU", false);
        }


    }
    /*
    public void growFunction()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rd.transform.localScale *= 1.5f;
        }
    }*/
    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.tag == "EatenThings")
        {
            rd.transform.localScale *= 1.1f;
            Destroy(cd.gameObject);
        }
        if(cd.tag == "PlayerSub")
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            Gamem gm = gameManagerObject.GetComponent<Gamem>();
            gm.playerGameObjects.Remove(cd.gameObject);
            Vector3 newScale = transform.localScale * 1.3f; 
            transform.localScale = newScale;
            Destroy(cd.gameObject);
            if (gm.countNum >= gm.playerGameObjects.Count)
            {
                gm.countNum = gm.countNum - gm.playerGameObjects.Count;
            }
            //gm.SwitchBetweenPlayer();
        }
        if(cd.tag =="Floor")
        {
            gameObject.SetActive(false);
        }

       
    }

    public void GotoSleep()
    {
        walking.SetBool("Sleeping", true);
    }
    public void WakeUp()
    {
        walking.SetBool("Sleeping", false);
    }


}
